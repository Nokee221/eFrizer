import 'dart:convert';

import 'package:flutter/material.dart';
import 'package:flutter_login/models/HairSalon.dart';
import 'package:flutter_login/models/hairsalon_type.dart';

class HairSalonHairSalonType{
  int hairsalonId;
  int hairsalontypeId;
  String hairSalonName;
  String hairSalonAdress;
  
  HairSalonHairSalonType({
    required this.hairsalonId,
    required this.hairsalontypeId,
    required this.hairSalonName,
    required this.hairSalonAdress,
  });

   factory HairSalonHairSalonType.fromJson(Map<String, dynamic> json) {
    return HairSalonHairSalonType(
      hairsalonId: int.parse(json['hairSalonId'].toString()),
      hairsalontypeId: int.parse(json['hairSalonTypeId'].toString()),
      hairSalonName: json['hairSalonName'],
      hairSalonAdress: json['hairSalonAdress'],
    );
  }

  
}