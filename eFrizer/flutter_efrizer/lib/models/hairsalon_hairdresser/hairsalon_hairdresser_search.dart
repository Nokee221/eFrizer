import 'package:flutter/material.dart';
import 'package:flutter_login/models/hairsalon_hairdresser/hairsalon_hairdresser.dart';

class HairSalonHairDresserSearchRequest{
   final int? hairdresserId;
   final int? hairsalonId;

   HairSalonHairDresserSearchRequest({
      this.hairdresserId,
      this.hairsalonId,
   });

   factory HairSalonHairDresserSearchRequest.fromJson(Map<String, dynamic> json) {
    return HairSalonHairDresserSearchRequest(
      hairdresserId: int.parse(json['hairDresserId'].toString()),
      hairsalonId: int.parse(json['hairSalonId'].toString()),
    );
  }
}