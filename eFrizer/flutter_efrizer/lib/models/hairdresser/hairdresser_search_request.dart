import 'package:flutter/material.dart';

class HairDresserSearchRequest{
  final int hairSalonId;

  HairDresserSearchRequest({
    required this.hairSalonId
  });

  factory HairDresserSearchRequest.fromJson(Map<String, dynamic> json) {
    return HairDresserSearchRequest(
      hairSalonId: int.parse(json['hairSalonId'].toString()),
    );

  }
    
}