import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:flutter_login/models/application_user/application_user.dart';
import 'package:flutter_login/models/loyalty_bonus/loyalty_bonus.dart';
import 'package:flutter_login/models/loyalty_bonus/loyalty_bonus_search_request.dart';
import 'package:flutter_login/models/loyalty_user/loyalty_user.dart';
import 'package:flutter_login/models/loyalty_user/loyalty_user_insert_request.dart';
import 'package:flutter_login/models/loyalty_user/loyalty_user_search_request.dart';
import 'package:flutter_login/models/loyalty_user/loyatly_user_update_request.dart';
import 'package:flutter_login/models/reservation/reservation_insert_request.dart';
import 'package:flutter_login/pages/mycard_paymant.dart';
import 'package:flutter_login/pages/payment_method.dart';
import 'package:flutter_login/pages/setting_page.dart';
import 'package:flutter_login/pages/success.dart';
import 'package:flutter_login/provider/dark_theme_provider.dart';
import 'package:flutter_login/services/api_service.dart';
import 'package:google_fonts/google_fonts.dart';
import 'package:provider/provider.dart';
import 'credit_card_page.dart';

class Payment extends StatefulWidget {
  final ApplicationUser user;
  final ReservationInsertRequest request;
  const Payment(this.user, this.request, {Key? key}) : super(key: key);

  @override
  _PaymentState createState() => _PaymentState(user, request);
}

class _PaymentState extends State<Payment> {
  final ApplicationUser user;
  final ReservationInsertRequest request;
  final icon = CupertinoIcons.moon_stars;
  Object? value = 0;

  _PaymentState(this.user, this.request);

  final paymentLabels = [
    'Credit card / Debit card',
    'My Credit Cards',
    'Cash on delivery',
  ];

  final paymentIcons = [
    Icons.credit_card,
    Icons.credit_card,
    Icons.money_off,
    Icons.payment,
    Icons.account_balance_wallet,
  ];

  var result = null;
  Future<void> putData() async {
    result = await APIService.post("Reservation", request);
  }

  var lytrequest = null;
  var lytrequestupdate = null;
  var lytbonusrequest = null;
  @override
  void initState() {
    lytrequest = LoyaltyBonusUserSearchRequest(
        clientId: request.clientId, hairSalonServiceId: request.serviceId);

    lytbonusrequest =
        LoyaltyBonusSearchRequest(hairsalonServiceId: request.serviceId);
    super.initState();
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
      backgroundColor: themeChange.darkTheme ? Colors.black : Colors.white,
      appBar: AppBar(
        leading: BackButton(color: Colors.blue),
        centerTitle: true,
        title: Text(
          "Payment",
          style: GoogleFonts.pacifico(
              color: themeChange.darkTheme ? Colors.white : Colors.black),
        ),
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
      body: Column(
        children: [
          const Padding(
            padding: const EdgeInsets.all(24.0),
            child: Text(
              "Choose your payment method",
              style: TextStyle(color: Color(0xFF808080), fontSize: 28.0),
            ),
          ),
          Expanded(
            child: ListView.separated(
              itemCount: paymentLabels.length,
              itemBuilder: (context, index) {
                return ListTile(
                  leading: Radio(
                    activeColor: Colors.blue,
                    value: index,
                    groupValue: value,
                    onChanged: (i) => setState(() => value = i),
                  ),
                  title: Text(
                    paymentLabels[index],
                    style: TextStyle(
                        color: themeChange.darkTheme
                            ? Colors.white
                            : Colors.black),
                  ),
                  trailing: Icon(
                    paymentIcons[index],
                    color: themeChange.darkTheme ? Colors.white : Colors.black,
                  ),
                );
              },
              separatorBuilder: (context, index) {
                return Divider();
              },
            ),
          ),
          Container(
            width: MediaQuery.of(context).size.width,
            margin: EdgeInsets.symmetric(vertical: 24.0),
            padding: EdgeInsets.symmetric(horizontal: 24.0),
            child: FlatButton(
              padding: EdgeInsets.symmetric(vertical: 10.0),
              shape: RoundedRectangleBorder(
                  borderRadius: BorderRadius.circular(30.0)),
              color: Colors.blue,
              textColor: Color(0xFFFFFFFF),
              highlightColor: Colors.transparent,
              onPressed: () async {
                if (value == 0) {
                  Navigator.of(context).push(
                    MaterialPageRoute(
                      builder: (context) => CreditCardPage(user, request),
                    ),
                  );
                } else if (value == 1) {
                  Navigator.of(context).push(
                    MaterialPageRoute(
                      builder: (context) =>
                          MyCardPayReservationPage(user, request),
                    ),
                  );
                } else {
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
                          onPressed: () {
                            Navigator.of(context).push(
                              MaterialPageRoute(
                                builder: (context) => Success(user),
                              ),
                            );
                          },
                        );
                        AlertDialog alert = AlertDialog(
                          title: Text("Successfully"),
                          content: Text("Successfully updatated loyalty bonus"),
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
                            onPressed: () {
                              Navigator.of(context).push(
                                MaterialPageRoute(
                                  builder: (context) => Success(user),
                                ),
                              );
                            },
                          );
                          AlertDialog alert = AlertDialog(
                            title: Text("Successfully"),
                            content: Text("Successfully added loyalty bonus"),
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
                  } else {
                    Widget okButton = TextButton(
                      child: Text("OK"),
                      onPressed: () {
                        Navigator.pop(context);
                      },
                    );
                    AlertDialog alert = AlertDialog(
                      title: Text("Error"),
                      content: Text("Unsuccessful reservation"),
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
              },
              child: Text("Pay".toUpperCase()),
            ),
          ),
        ],
      ),
    );
  }
}
