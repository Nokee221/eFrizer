import 'package:flutter/material.dart';

class HairSalonHairSalonTypeSearchRequest{
  String? hairsalontypeName;

  HairSalonHairSalonTypeSearchRequest({
    this.hairsalontypeName
  });

  factory HairSalonHairSalonTypeSearchRequest.fromJson(Map<String, dynamic> json) {
    return HairSalonHairSalonTypeSearchRequest(
      hairsalontypeName: json["name"],
    );
  }
}