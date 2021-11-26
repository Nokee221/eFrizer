import 'package:flutter/material.dart';
import 'dart:convert';

class HairSalon{
  final int HairSalonId;
  final String Name; 
  final String Description; 
  final String Address;
  final int CityId;

  HairSalon({
    required this.HairSalonId,
    required this.Name,
    required this.Description,
    required this.Address,
    required this.CityId
  });

  factory HairSalon.fromJson(Map<String,dynamic> json)
  {
    return HairSalon(
      HairSalonId: int.parse(json["hairSalonId"].toString()),
      Name: json["name"],
      Description: json["description"],
      Address: json["address"],
      CityId: int.parse(json["cityId"].toString())
    );
  }


  Map<String,dynamic> toJson() =>{
    "hairSalonId": HairSalonId,
    "name":Name,
    "description": Description,
    "address": Address,
    "cityId": CityId,
  };
} 