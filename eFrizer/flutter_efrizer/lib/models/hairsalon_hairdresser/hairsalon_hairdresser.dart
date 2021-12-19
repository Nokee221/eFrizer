import 'package:flutter/material.dart';

class HairSalonHairDresser{
  final int hairdresserId;

  final String hairdresserName;


  HairSalonHairDresser({
    required this.hairdresserId,
    required this.hairdresserName,
  });

  factory HairSalonHairDresser.fromJson(Map<String, dynamic> json) {
    return HairSalonHairDresser(
      hairdresserId: int.parse(json['hairDresserId'].toString()),
      hairdresserName: json['hairDresserName']
    );
  }
}