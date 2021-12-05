import 'package:flutter/material.dart';

class HairSalonSearchRequest{
  String? name;
  

  HairSalonSearchRequest({
     this.name
  });

  factory HairSalonSearchRequest.fromJson(Map<String, dynamic> json) {
    return HairSalonSearchRequest(
      name: json["name"],
    );
  }
}