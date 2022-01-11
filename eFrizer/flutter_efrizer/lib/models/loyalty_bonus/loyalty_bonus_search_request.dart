class LoyaltyBonusSearchRequest{
  int hairSalonId;

  LoyaltyBonusSearchRequest({
    required this.hairSalonId
  });

  factory LoyaltyBonusSearchRequest.fromJson(Map<String, dynamic> json) {
    return LoyaltyBonusSearchRequest(
      hairSalonId: int.parse(json['hairSalonId'].toString()),
    );
  }
}