import 'package:flutter/material.dart';
import 'dart:convert';
import 'package:json_annotation/json_annotation.dart';

part 'HairSalon.g.dart';

@JsonSerializable()
class HairSalon {
  final int HairSalonId;
  final String Name;
  final String Description;
  final String Address;
  final int CityId;
  final int FeaturedPictureId;

  HairSalon(
      {required this.HairSalonId,
      required this.Name,
      required this.Description,
      required this.Address,
      required this.CityId,
      required this.FeaturedPictureId});

  factory HairSalon.fromJson(Map<String, dynamic> data) =>
      _$HairSalonFromJson(data);

  Map<String, dynamic> toJson() => _$HairSalonToJson(this);
}
