import 'package:flutter/material.dart';
import 'package:flutter_login/models/review/review.dart';

class ReviewInsertRequest{
  final int hairSalonId;
  final int clientId;
  final int starrating;

  ReviewInsertRequest({
    required this.hairSalonId,
    required this.clientId,
    required this.starrating,
  });

  Map<String, dynamic> toJson() => {
        "hairSalonId": hairSalonId,
        "clientId": clientId,
        "starRating": starrating,
      };
}