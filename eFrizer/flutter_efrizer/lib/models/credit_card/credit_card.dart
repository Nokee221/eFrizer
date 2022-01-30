class CreditCard{
  final int creditCardId;
  final String cardName;
  final String expiryDate;
  final String cardHolderName;
  final String cvvCode;

  CreditCard({
    required this.creditCardId,
    required this.cardName,
    required this.expiryDate,
    required this.cardHolderName,
    required this.cvvCode
  });

  factory CreditCard.fromJson(Map<String, dynamic> json) {
    return CreditCard(
      creditCardId: int.parse(json['creditCardId'].toString()),
      cardName: json['cardNumber'],
      expiryDate: json['expiryDate'],
      cardHolderName: json['cardHolderName'],
      cvvCode: json['cvvCode'],
    );
  }

}