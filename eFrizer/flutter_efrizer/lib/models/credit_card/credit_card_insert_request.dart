class CreditCardInsertRequest{
  final String cardName;
  final String expiryDate;
  final String cardHolderName;
  final String cvvCode;
  final int clientId;

  CreditCardInsertRequest({
    required this.clientId,
    required this.cardName,
    required this.cardHolderName,
    required this.expiryDate,
    required this.cvvCode
  });

  Map<String, dynamic> toJson() => {
        "cardNumber": cardName,
        "expiryDate": expiryDate,
        "cardHolderName": cardHolderName,
        "cvvCode": cvvCode,
        "clientId": clientId,
      };
}