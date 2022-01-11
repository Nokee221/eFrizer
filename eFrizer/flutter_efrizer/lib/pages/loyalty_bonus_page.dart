import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:flutter_login/models/HairSalon.dart';
import 'package:flutter_login/models/loyalty_bonus/loyalty_bonus.dart';

class LoyaltyBonusPage extends StatefulWidget {
  final LoyaltyBonus loyaltyBonus;
  const LoyaltyBonusPage(this.loyaltyBonus, {Key? key}) : super(key: key);

  @override
  _LoyaltyBonusPageState createState() => _LoyaltyBonusPageState(loyaltyBonus);
}

class _LoyaltyBonusPageState extends State<LoyaltyBonusPage> {
  final LoyaltyBonus loyaltyBonus;
  final icon = CupertinoIcons.moon_stars;
  final String assetName = 'assets/hairdresser.svg';

  _LoyaltyBonusPageState(this.loyaltyBonus);

  @override
  Widget build(BuildContext context) {
    return Scaffold(
        appBar: AppBar(
          leading: BackButton(color: Colors.blue),
          backgroundColor: Colors.transparent,
          elevation: 0,
          actions: [
            IconButton(
              icon: Icon(icon),
              color: Colors.blue,
              onPressed: () {},
            ),
          ],
        ),
        body: ListView(children: <Widget>[
          ListView(
              padding: EdgeInsets.symmetric(horizontal: 20),
              physics: NeverScrollableScrollPhysics(),
              primary: false,
              shrinkWrap: true,
              children: <Widget>[
                Row(
                  mainAxisAlignment: MainAxisAlignment.spaceBetween,
                  children: <Widget>[
                    Flexible(
                      child: Container(
                        alignment: Alignment.centerLeft,
                        child: Text(
                          "Za uslugu " +
                              loyaltyBonus.serviceName +
                              " na svaku " +
                              loyaltyBonus.activatesOn.toString() +
                              ". kupovinu ostvarujete " +
                              loyaltyBonus.discount.toString() +
                              "% popusta koji vrijedi " +
                              loyaltyBonus.expiresIn.toString() +
                              " dana od trenutka " +
                              loyaltyBonus.activatesOn.toString() +
                              ". kupovine.",
                          style: const TextStyle(
                            fontWeight: FontWeight.w700,
                            fontSize: 20,
                          ),
                          textAlign: TextAlign.left,
                        ),
                      ),
                    ),
                    IconButton(
                      icon: const Icon(
                        Icons.bookmark,
                      ),
                      onPressed: () {},
                    )
                  ],
                )
              ])
        ]));
  }
}
