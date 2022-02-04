// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'HairSalon.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

HairSalon _$HairSalonFromJson(Map<String, dynamic> json) => HairSalon(
    HairSalonId: int.parse(json["hairSalonId"].toString()),
    Name: json["name"],
    Description: json["description"],
    Address: json["address"],
    CityId: int.parse(json["cityId"].toString()),
    FeaturedPictureId: int.parse(json["featuredPictureId"].toString()));

Map<String, dynamic> _$HairSalonToJson(HairSalon instance) => <String, dynamic>{
      'HairSalonId': instance.HairSalonId,
      'Name': instance.Name,
      'Description': instance.Description,
      'Address': instance.Address,
      'CityId': instance.CityId,
    };
