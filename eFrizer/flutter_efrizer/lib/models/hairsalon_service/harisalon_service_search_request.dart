import 'package:flutter/material.dart';

class HairSalonServiceSearchRequest{
  final int hairsalonId;

  HairSalonServiceSearchRequest({
    required this.hairsalonId
  });

  factory HairSalonServiceSearchRequest.fromJson(Map<String, dynamic> json) {
    return HairSalonServiceSearchRequest(
      hairsalonId: int.parse(json['hairsalonId'].toString()),
    );
  }
}