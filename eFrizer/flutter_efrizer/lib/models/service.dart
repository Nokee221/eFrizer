import 'dart:ffi';
import 'package:flutter/material.dart';


class Service{
  int? ServiceId;
  String? Name;
  String? Description;
  int Price;
  int? TimeMin;

  Service({
    this.ServiceId,
    this.Name,
    this.Description,
    required this.Price,
    this.TimeMin,
  });

  factory Service.fromJson(Map<String, dynamic> json) {
    return Service(
      ServiceId: int.parse(json['serviceId'].toString()),
      Name: json['name'],
      Description: json['description'],
      Price: int.parse(json['price'].toString()),
      TimeMin: int.parse(json['timeMin'].toString()),
    );
  }

  Map<String, dynamic> toJson() => {
        
      };

}