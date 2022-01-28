import 'package:flutter/material.dart';

class Review{
  final int reviewId;
  final int hairsalonId;
  final int? clientId;
  final int? starrating;

  Review({
    required this.reviewId,
    required this.hairsalonId,
    this.clientId,
    this.starrating
  });

  factory Review.fromJson(Map<String, dynamic> json) {
    return Review(
      reviewId: int.parse(json['reviewId'].toString()),
      hairsalonId: int.parse(json['hairSalonId'].toString()),
      clientId: int.parse(json['clientId'].toString()),
      starrating: int.parse(json['starRating'].toString())
    );
  }
}