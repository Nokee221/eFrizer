import 'package:flutter/material.dart';

class Review{
  final int reviewId;
  final int hairsalonId;
  final int clientId;
  final String? text;
  final int? starrating;

  Review({
    required this.reviewId,
    required this.hairsalonId,
    required this.clientId,
    this.text,
    this.starrating
  });

  factory Review.fromJson(Map<String, dynamic> json) {
    return Review(
      reviewId: int.parse(json["reviewId"].toString()),
      hairsalonId: int.parse(json["hairSalonId"].toString()),
      clientId: int.parse(json["clientId"].toString()),
      text: json['text'],
      starrating: int.parse(json['starRating'].toString())
    );
  }
}