class TextReviewInsertRequest{
  final int hairsalonId;
  final int clientId;
  final String text;

  TextReviewInsertRequest({
    required this.hairsalonId,
    required this.clientId,
    required this.text,
  });

  Map<String, dynamic> toJson() => {
        "hairSalonId": hairsalonId,
        "clientId": clientId,
        "text": text,
      };
}