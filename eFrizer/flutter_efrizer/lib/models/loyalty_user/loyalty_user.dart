import 'package:flutter/material.dart';

class LoyatlyUser{
  final int loyaltybonusId;
  final int clientId;
  final int counter;


  LoyatlyUser({
    required this.counter,
    required this.clientId,
    required this.loyaltybonusId
  });

   factory LoyatlyUser.fromJson(Map<String, dynamic> json) {
    return LoyatlyUser(
      loyaltybonusId: int.parse(json['loyaltyBonusId'].toString()),
      clientId: int.parse(json['clientId'].toString()),
      counter: int.parse(json['counter'].toString())
    );
  }
}