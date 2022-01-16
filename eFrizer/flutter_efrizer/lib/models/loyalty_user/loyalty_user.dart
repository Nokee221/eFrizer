import 'package:flutter/material.dart';

class LoyaltyUser{
  final int id;
  final int hairSalonServiceLoyaltyBonusId;
  final int clientId;
  final int counter;


  LoyaltyUser({
    required this.id,
    required this.counter,
    required this.clientId,
    required this.hairSalonServiceLoyaltyBonusId
  });

   factory LoyaltyUser.fromJson(Map<String, dynamic> json) {
    return LoyaltyUser(
      id: int.parse(json['id'].toString()),
      hairSalonServiceLoyaltyBonusId: int.parse(json['hairSalonServiceLoyaltyBonusId'].toString()),
      clientId: int.parse(json['clientId'].toString()),
      counter: int.parse(json['counter'].toString())
    );
  }
}