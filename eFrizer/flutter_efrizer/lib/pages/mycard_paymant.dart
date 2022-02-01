import 'dart:ffi';
import 'dart:math';

import 'package:flutter/material.dart';
import 'package:flutter_credit_card/credit_card_widget.dart';
import 'package:flutter_login/models/application_user/application_user.dart';
import 'package:flutter_login/models/credit_card/credit_card.dart';
import 'package:flutter_login/models/credit_card/credit_card_search_request.dart';
import 'package:flutter_login/models/loyalty_bonus/loyalty_bonus.dart';
import 'package:flutter_login/models/loyalty_bonus/loyalty_bonus_search_request.dart';
import 'package:flutter_login/models/loyalty_user/loyalty_user.dart';
import 'package:flutter_login/models/loyalty_user/loyalty_user_insert_request.dart';
import 'package:flutter_login/models/loyalty_user/loyalty_user_search_request.dart';
import 'package:flutter_login/models/loyalty_user/loyatly_user_update_request.dart';
import 'package:flutter_login/models/reservation/reservation_insert_request.dart';
import 'package:flutter_login/pages/success.dart';
import 'package:flutter_login/provider/dark_theme_provider.dart';
import 'package:flutter_login/services/api_service.dart';
import 'package:google_fonts/google_fonts.dart';
import 'package:provider/provider.dart';

class MyCardPayReservationPage extends StatefulWidget {
  final ApplicationUser user;
  final ReservationInsertRequest request;
  const MyCardPayReservationPage(this.user ,this.request, {Key? key}) : super(key: key);

  @override
  _MyCardPayReservationPageState createState() =>
      _MyCardPayReservationPageState(user ,request);
}

class _MyCardPayReservationPageState extends State<MyCardPayReservationPage> {
  final ApplicationUser user;
  final ReservationInsertRequest request;
  _MyCardPayReservationPageState(this.user , this.request);

  var req = null;
  var lytrequest = null;
  var lytrequestupdate = null;
  var lytbonusrequest = null;
  @override
  void initState() {
    // TODO: implement initState

    req = CreditCardSearchRequest(clientId: request.clientId);

    lytrequest = LoyaltyBonusUserSearchRequest(
        clientId: request.clientId, hairSalonServiceId: request.serviceId);

    lytbonusrequest =
        LoyaltyBonusSearchRequest(hairsalonServiceId: request.serviceId);
    super.initState();
    super.initState();
  }

  var result = null;
  Future<void> putData() async {
    result = await APIService.post("Reservation", request);
  }

  late LoyaltyUser? lylresult;
  Future<void> getLoyalty() async {
    Map<String, String>? queryParams = null;
    if (lytrequest != null && queryParams != "")
      queryParams = {
        'ClientId': lytrequest.clientId.toString(),
        'HairSalonServiceId': lytrequest.hairSalonServiceId.toString()
      };

    lylresult = await APIService.getLoyalty("LoyaltyBonusUser", queryParams);
  }

  var updateresult = null;
  Future<void> updateLoyalty(id, tcounter) async {
    var updaterequest = LoyaltyBonusUserUpdateRequest(counter: tcounter);

    updateresult = await APIService.updateLoyalty(
        "LoyaltyBonusUser", id.toString(), updaterequest);
  }

  late LoyaltyBonus? lylbonusresult;
  Future<void> getLoyaltyBonus() async {
    Map<String, String>? queryParams = null;
    if (lytbonusrequest != null && queryParams != "")
      queryParams = {
        'hairSalonServiceId': lytbonusrequest.hairsalonServiceId.toString()
      };

    lylbonusresult = await APIService.getLoyaltyBonus(
        "HairSalonServiceLoyaltyBonus", queryParams);
  }


  var lyluserinsertrequest = null;
  var lyluserinsertresult = null;
  Future<void> putLoyalty(id) async {
    lyluserinsertrequest = LoyatlyBonusUserInsertRequest(
        clientId: request.clientId, hairSalonServiceLoyaltyBonusId: id);
    lyluserinsertresult =
        await APIService.post("LoyaltyBonusUser", lyluserinsertrequest);
  }

  @override
  Widget build(BuildContext context) {
    final themeChange = Provider.of<DarkThemeProvider>(context);

    return Scaffold(
      appBar: AppBar(
        leading: BackButton(color: Colors.blue),
        centerTitle: true,
        title: Text(
          "Credit Cards",
          style: GoogleFonts.pacifico(
              color: themeChange.darkTheme ? Colors.white : Colors.black),
        ),
        backgroundColor: Colors.transparent,
        elevation: 0,
      ),
      body: Column(
        children: [
          const Padding(
            padding: EdgeInsets.all(24.0),
            child: Text(
              "Choose credit card",
              style: TextStyle(
                color: Color(0xFF808080),
                fontSize: 24.0,
              ),
            ),
          ),
          Expanded(
            child: Container(
              width: double.infinity,
              height: double.infinity,
              child: listCard(),
            ),
          )
        ],
      ),
    );
  }

  Widget listCard() {
    return FutureBuilder<List<CreditCard>>(
        future: getCreditCards(request),
        builder:
            (BuildContext context, AsyncSnapshot<List<CreditCard>> snapshot) {
          if (snapshot.connectionState == ConnectionState.waiting) {
            return Center(
              child: Text('Loading...'),
            );
          } else {
            if (snapshot.hasError) {
              return Center(
                child: Text('${snapshot.error}'),
              );
            } else {
              return ListView(
                scrollDirection: Axis.vertical,
                physics: ScrollPhysics(),
                children:
                    snapshot.data!.map((e) => _MyCreditCardWidget(e)).toList(),
              );
            }
          }
        });
  }

  Future<List<CreditCard>> getCreditCards(req) async {
    Map<String, String>? queryParams = null;
    if (req != null && queryParams != "")
      queryParams = {'ClientId': req.clientId.toString()};

    var card = await APIService.get('CreditCard', queryParams);
    return card!.map((i) => CreditCard.fromJson(i)).toList();
  }

  Widget _MyCreditCardWidget(card) => InkWell(
        onTap: () async {
          await putData();
          if (result != null) {
            await getLoyalty();
            if (lylresult != null) {
              int tempcounter = 0;
              //update
              tempcounter = lylresult!.counter;
              tempcounter += 1;

              await updateLoyalty(lylresult!.id, tempcounter);
              if (updateresult != null) {
                Widget okButton = TextButton(
                  child: Text("OK"),
                  onPressed: () {},
                );
                AlertDialog alert = AlertDialog(
                  title: Text("Error"),
                  content: Text("Uspjesno updateovan loyalty bonus"),
                  actions: [
                    okButton,
                  ],
                );
                showDialog(
                    context: context,
                    builder: (BuildContext context) {
                      return alert;
                    });
              }
            } else {
              await getLoyaltyBonus();
              if (lylbonusresult != null) {
                await putLoyalty(lylbonusresult!.id);
                if (lyluserinsertresult != null) {
                  Widget okButton = TextButton(
                    child: Text("OK"),
                    onPressed: () {},
                  );
                  AlertDialog alert = AlertDialog(
                    title: Text("Error"),
                    content: Text("Uspjesno dodan loyalty bonus"),
                    actions: [
                      okButton,
                    ],
                  );
                  showDialog(
                      context: context,
                      builder: (BuildContext context) {
                        return alert;
                      });
                }
              }
            }

            Navigator.of(context).push(
              MaterialPageRoute(
                builder: (context) => Success(user),
              ),
            );
          } else {
            Widget okButton = TextButton(
              child: Text("OK"),
              onPressed: () {},
            );
            AlertDialog alert = AlertDialog(
              title: Text("Error"),
              content: Text("Bezuspjesna rezervacija"),
              actions: [
                okButton,
              ],
            );
            showDialog(
                context: context,
                builder: (BuildContext context) {
                  return alert;
                });
          }
        },
        child: CreditCardWidget(
          cardBgColor:
              Colors.primaries[Random().nextInt(Colors.primaries.length)],
          height: 200,
          cardNumber: card.cardName,
          expiryDate: card.expiryDate,
          cardHolderName: card.cardHolderName,
          cvvCode: card.cvvCode,
          showBackView: false,
          obscureCardNumber: true,
          obscureCardCvv: true,
          isHolderNameVisible: true,
          onCreditCardWidgetChange: (CreditCardBrand) {},
        ),
      );
}
