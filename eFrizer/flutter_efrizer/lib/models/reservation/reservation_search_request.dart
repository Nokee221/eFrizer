import 'package:flutter/material.dart';

class ReservationSearchRequest{
  int? applicationuserId;
  int? hairdresserId;
  int? day;
  int? month;

  ReservationSearchRequest({
    this.applicationuserId,
    this.hairdresserId,
    this.day,
    this.month
  });

  factory ReservationSearchRequest.fromJson(Map<String,dynamic> json)
  {
    return ReservationSearchRequest(
      applicationuserId: int.parse(json['clientId'].toString()),
      hairdresserId: int.parse(json['hairDresserId']),
    );
  }
}