// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'hairsalon_hairsalontype_model.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

HairSalonHairSalonType _$HairSalonHairSalonTypeFromJson(
        Map<String, dynamic> json) =>
    HairSalonHairSalonType(
      hairsalonId: int.parse(json['hairSalonId'].toString()),
      hairsalontypeId: int.parse(json['hairSalonTypeId'].toString()),
      hairSalonName: json['hairSalonName'],
      hairSalonAdress: json['hairSalonAdress'],
      hairSalon: HairSalon.fromJson(json['hairSalon'] as Map<String, dynamic>),
    );

Map<String, dynamic> _$HairSalonHairSalonTypeToJson(
        HairSalonHairSalonType instance) =>
    <String, dynamic>{
      'hairsalonId': instance.hairsalonId,
      'hairsalontypeId': instance.hairsalontypeId,
      'hairSalon': instance.hairSalon.toJson(),
      'hairSalonName': instance.hairSalonName,
      'hairSalonAdress': instance.hairSalonAdress,
    };
