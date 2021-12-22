import 'package:flutter/material.dart';
import 'package:flutter_login/models/reservation/reservation_search_request.dart';

class ReviewSearchRequest{
  final int hairsalonId;

  ReviewSearchRequest({
    required this.hairsalonId
  });

  factory ReviewSearchRequest.fromJson(Map<String, dynamic> json) {
    return ReviewSearchRequest(
      hairsalonId: int.parse(json['hairSalonId'].toString()),
    );
  }
}