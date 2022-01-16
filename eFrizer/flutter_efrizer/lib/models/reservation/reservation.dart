import 'package:flutter/material.dart';

class Reservation{
  final int reservationId;
  final int HairDresserId;
  final int? ClientId;
  final int? hairSalonServiceId;
  final DateTime From;
  final DateTime To;

  final String HairDresserName;
 


  Reservation({
    required this.reservationId,
    required this.ClientId,
    required this.HairDresserId,
    required this.hairSalonServiceId,
    required this.From,
    required this.To,
    required this.HairDresserName,

  });

 

  factory Reservation.fromJson(Map<String, dynamic> json) {
    return Reservation(
      reservationId: int.parse(json['reservationId'].toString()),
      HairDresserId: int.parse(json['hairDresserId'].toString()),
      ClientId: int.parse(json['clientId'].toString()),
      hairSalonServiceId: int.parse(json['hairSalonServiceId'].toString()),
      From: DateTime.parse(json['from']),
      To: DateTime.parse(json['to']),
      HairDresserName: json['hairDresserName'],

    );
  }

  Map<String, dynamic> toJson() => {};
}
