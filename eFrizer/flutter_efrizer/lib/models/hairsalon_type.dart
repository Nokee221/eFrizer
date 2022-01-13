import 'package:flutter/material.dart';
import 'package:flutter_login/models/hairsalon/HairSalon.dart';

class HairSalonType{
  int hairsalontypeId;
  String name;

  HairSalonType({
    required this.hairsalontypeId,
    required this.name,
  });

  factory HairSalonType.fromJson(Map<String, dynamic> json) {
    return HairSalonType(
      hairsalontypeId: int.parse(json["hairSalonTypeId"].toString()),
      name: json["name"],
    );
  }
}