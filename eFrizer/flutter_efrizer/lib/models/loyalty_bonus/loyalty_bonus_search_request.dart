class LoyaltyBonusSearchRequest{
  int? hairsalonServiceId;
  int? hairSalonId;

  LoyaltyBonusSearchRequest({
    this.hairsalonServiceId,
    this.hairSalonId

  });

  factory LoyaltyBonusSearchRequest.fromJson(Map<String, dynamic> json) {
    return LoyaltyBonusSearchRequest(
      hairsalonServiceId: int.parse(json['hairSalonServiceId'].toString()),
      hairSalonId: int.parse(json['hairSalonId'].toString()),
    );
  }
}