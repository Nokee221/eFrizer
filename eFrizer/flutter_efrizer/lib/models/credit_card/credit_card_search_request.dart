class CreditCardSearchRequest{
  final int clientId;

  CreditCardSearchRequest({
    required this.clientId
  });

  factory CreditCardSearchRequest.fromJson(Map<String, dynamic> json) {
    return CreditCardSearchRequest(
      clientId: int.parse(json['clientId'].toString()),
    );
  }
}