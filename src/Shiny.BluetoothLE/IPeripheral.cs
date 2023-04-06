﻿using System;
using System.Collections.Generic;

namespace Shiny.BluetoothLE;


public record BleServiceInfo(string Uuid);

public record BleCharacteristicInfo(
    BleServiceInfo Service,
    string Uuid,
    bool IsNotifying,
    CharacteristicProperties Properties
);
public record BleDescriptorInfo(
    BleCharacteristicInfo Characteristic,
    string Uuid
);
public record BleCharacteristicResult(
    BleCharacteristicInfo Characteristic,
    BleCharacteristicEvent Event,
    byte[]? Data
);
public enum BleCharacteristicEvent
{
    Read,
    Write,
    WriteWithoutResponse,
    Notification
}

public record BleDescriptorResult(
    BleDescriptorInfo Descriptor,
    byte[]? Data
);

public interface IPeripheral
{
    string Uuid { get; }
    string? Name { get; }
    int Mtu { get; }
    ConnectionState Status { get; } // TODO: add failed state?

    void Connect(ConnectionConfig? config);
    void CancelConnection();
    IObservable<ConnectionState> WhenStatusChanged();
    IObservable<int> ReadRssi();

    IObservable<BleServiceInfo> GetService(string serviceUuid);
    IObservable<IReadOnlyList<BleServiceInfo>> GetServices(bool refreshServices = false);

    IObservable<BleCharacteristicInfo> GetCharacteristic(string serviceUuid, string characteristicUuid);
    IObservable<IReadOnlyList<BleCharacteristicInfo>> GetCharacteristics(string serviceUuid);
    IObservable<BleCharacteristicResult> NotifyCharacteristic(string serviceUuid, string characteristicUuid, bool useIndicationsIfAvailable = true, bool autoReconnect = true);
    IObservable<BleCharacteristicResult> ReadCharacteristic(string serviceUuid, string characteristicUuid);
    IObservable<BleCharacteristicResult> WriteCharacteristic(string serviceUuid, string characteristicUuid, byte[] data, bool withResponse = true);

    IObservable<BleDescriptorInfo> GetDescriptor(string serviceUuid, string characteristicUuid, string descriptorUuid);
    IObservable<IReadOnlyList<BleDescriptorInfo>> GetDescriptors(string serviceUuid, string characteristicUuid);
    IObservable<BleDescriptorResult> ReadDescriptor(string serviceUuid, string characteristicUuid, string descriptorUuid);
    IObservable<BleDescriptorResult> WriteDescriptor(string serviceUuid, string characteristicUuid, string descriptorUuid, byte[] data);
}