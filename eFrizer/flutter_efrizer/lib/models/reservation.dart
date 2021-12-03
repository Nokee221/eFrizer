import 'dart:ffi';

import 'package:flutter/material.dart';

class Reservation{
  final int HairDresserId;
  final int ClientId;
  final int ServiceId;
  final DateTime From;
  final DateTime To;


  Reservation({
    required this.ClientId,
    required this.HairDresserId,
    required this.ServiceId,
    required this.From,
    required this.To,
  });

 

  factory Reservation.fromJson(Map<String, dynamic> json) {
    return Reservation(
      HairDresserId: int.parse(json['hairDresserId'].toString()),
      ClientId: int.parse(json['clientId'].toString()),
      ServiceId: int.parse(json['serviceId'].toString()),
      From: DateTime.parse(json['from']),
      To: DateTime.parse(json['to']),
    );
  }

  Map<String, dynamic> toJson() => {
        
      };
}
