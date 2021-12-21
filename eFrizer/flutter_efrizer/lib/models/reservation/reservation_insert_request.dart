import 'package:flutter/material.dart';
import 'package:intl/intl.dart';

class ReservationInsertRequest{
  final int hairDresserId;
  final int clientId;
  final int? serviceId;


  final String to;
  final String? from;

  ReservationInsertRequest({
    required this.hairDresserId,
    required this.clientId,
    required this.serviceId,
    required this.from,
    required this.to,
  });

  factory ReservationInsertRequest.fromJson(Map<String,dynamic> json)
  {
    return ReservationInsertRequest(
      hairDresserId: int.parse(json['hairDresserId'].toString()),
      clientId: int.parse(json['clientId'].toString()),
      serviceId: int.parse(json['serviceId'].toString()),
      to: json['to'],
      from: json['from'],
    );
  }

  Map<String, dynamic> toJson() => {
        "hairDresserId": hairDresserId,
        "clientId": clientId,
        "serviceId": serviceId,
        "to": to,
        "from": from,
      };
  
}