import 'package:flutter/material.dart';

class HairSalonHairSalonTypeSearchRequest{
  int hairsalontypeId;

  HairSalonHairSalonTypeSearchRequest({
    required this.hairsalontypeId
  });

  factory HairSalonHairSalonTypeSearchRequest.fromJson(Map<String, dynamic> json) {
    return HairSalonHairSalonTypeSearchRequest(
      hairsalontypeId: int.parse(json['hairSalonTypeId'].toString()),
    );
  }
}