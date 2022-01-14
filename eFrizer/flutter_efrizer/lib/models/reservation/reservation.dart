import 'dart:ffi';

import 'package:flutter/material.dart';

class Reservation {
  final int HairDresserId;
  final int? ClientId;
  final int HairSalonServiceId;
  final DateTime From;
  final DateTime To;

  final String HairDresserName;
  final String ServiceName;

  Reservation(
      {required this.ClientId,
      required this.HairDresserId,
      required this.HairSalonServiceId,
      required this.From,
      required this.To,
      required this.HairDresserName,
      required this.ServiceName});

  factory Reservation.fromJson(Map<String, dynamic> json) {
    return Reservation(
        HairDresserId: int.parse(json['hairDresserId'].toString()),
        ClientId: int.parse(json['clientId'].toString()),
        HairSalonServiceId: int.parse(json['hairSalonServiceId'].toString()),
        From: DateTime.parse(json['from']),
        To: DateTime.parse(json['to']),
        HairDresserName: json['hairDresserName'],
        ServiceName: json['serviceName']);
  }

  Map<String, dynamic> toJson() => {};
}
