import 'dart:ffi';

import 'package:flutter/material.dart';


class Service{
  int? ServiceId;
  String? Name;
  String? Description;
  Float? Price;
  int? TimeMin;

  Service({
    this.ServiceId,
    this.Name,
    this.Description,
    this.Price,
    this.TimeMin,
  });

  factory Service.fromJson(Map<String, dynamic> json) {
    return Service(
      ServiceId: int.parse(json['serviceId'].toString()),
      Name: json['name'],
      Description: json['description'],
      Price: json['price'],
      TimeMin: int.parse(json['timeMin'].toString()),
    );
  }

  Map<String, dynamic> toJson() => {
        
      };

}