import 'package:flutter/cupertino.dart';

class TextReview{
  final int textReviewId;
  final int hairSalonId;
  final int clientId;
  final String text;
  String? clientName;

  TextReview({
    required this.textReviewId,
    required this.hairSalonId,
    required this.clientId,
    required this.text,
    this.clientName,
  });

  factory TextReview.fromJson(Map<String, dynamic> json) {
    return TextReview(
      textReviewId: int.parse(json['textReviewId'].toString()),
      hairSalonId: int.parse(json['hairSalonId'].toString()),
      clientId: int.parse(json['clientId'].toString()),
      text: json['text'],
      clientName: json['clientUsername'],
    );
  }

}