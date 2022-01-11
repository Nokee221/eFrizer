import 'dart:convert';

import 'package:flutter/material.dart';
import 'package:flutter_login/models/HairSalon.dart';
import 'package:flutter_login/models/hairsalon_type.dart';
import 'package:json_annotation/json_annotation.dart';

part 'hairsalon_hairsalontype_model.g.dart';


@JsonSerializable(explicitToJson: true)
class HairSalonHairSalonType{
  int hairsalonId;
  int hairsalontypeId;
  HairSalon hairSalon;
  String hairSalonName;
  String hairSalonAdress;
  
  HairSalonHairSalonType({
    required this.hairsalonId,
    required this.hairsalontypeId,
    required this.hairSalonName,
    required this.hairSalonAdress,
    required this.hairSalon,
  });

   /*factory HairSalonHairSalonType.fromJson(Map<String, dynamic> json) {
    return HairSalonHairSalonType(
      hairsalonId: int.parse(json['hairSalonId'].toString()),
      hairsalontypeId: int.parse(json['hairSalonTypeId'].toString()),
      hairSalonName: json['hairSalonName'],
      hairSalonAdress: json['hairSalonAdress'],
      hairSalon: HairSalon.fromJson(json),
    );
  }*/

  factory HairSalonHairSalonType.fromJson(Map<String,dynamic> data) => _$HairSalonHairSalonTypeFromJson(data);

  Map<String,dynamic> toJson() => _$HairSalonHairSalonTypeToJson(this);

  
}