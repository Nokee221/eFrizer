class TextReviewSearchRequest{
  final int hairSalonId;
  final int clientId;

  TextReviewSearchRequest({
    required this.hairSalonId,
    required this.clientId,
  });

  factory TextReviewSearchRequest.fromJson(Map<String, dynamic> json) {
    return TextReviewSearchRequest(
      hairSalonId: int.parse(json['hairSalonId'].toString()),
      clientId: int.parse(json['clientId'].toString()),
    );
  }
}