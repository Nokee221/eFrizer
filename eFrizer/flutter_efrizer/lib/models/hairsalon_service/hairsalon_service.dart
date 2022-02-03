class HairSalonService{
  final int hairSalonServiceId;
  final String description;
  final int price;
  final int timeMin;
  final int serviceId;
  final String serviceName;

  HairSalonService({
    required this.hairSalonServiceId,
    required this.description,
    required this.price,
    required this.serviceId,
    required this.timeMin,
    required this.serviceName
  });


  factory HairSalonService.fromJson(Map<String, dynamic> json) {
    return HairSalonService(
      hairSalonServiceId: int.parse(json['hairSalonServiceId'].toString()),
      description: json['description'],
      price: int.parse(json['price'].toString()),
      timeMin: int.parse(json['timeMin'].toString()),
      serviceId: int.parse(json['serviceId'].toString()),
      serviceName: json['serviceName']
    );
  }

}