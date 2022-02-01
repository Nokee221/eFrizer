import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:flutter_credit_card/flutter_credit_card.dart';
import 'package:flutter_login/models/application_user/application_user.dart';
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

class CreditCardPage extends StatefulWidget {
  final ApplicationUser user;
  final ReservationInsertRequest request;
  const CreditCardPage(this.user ,this.request, {Key? key}) : super(key: key);

  @override
  _CreditCardPageState createState() => _CreditCardPageState(user ,request);
}

class _CreditCardPageState extends State<CreditCardPage> {
  final ApplicationUser user;
  final ReservationInsertRequest request;
  final icon = CupertinoIcons.moon_stars;

  _CreditCardPageState(this.user ,this.request);

  String cardNumber = '';
  String expiryDate = '';
  String cardHolderName = '';
  String cvvCode = '';
  bool isCvvFocused = false;

  final GlobalKey<FormState> formKey = GlobalKey<FormState>();

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
      backgroundColor: Colors.white,
      appBar: AppBar(
        leading: BackButton(color: Colors.blue),
        centerTitle: true,
        title: Text(
          "Credit Card",
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
      body: SafeArea(
        child: Column(
          children: [
            CreditCardWidget(
              cardNumber: cardNumber,
              expiryDate: expiryDate,
              cardHolderName: cardHolderName,
              cvvCode: cvvCode,
              showBackView: isCvvFocused,
              obscureCardNumber: true,
              obscureCardCvv: true,
              isHolderNameVisible: true,
              onCreditCardWidgetChange: (CreditCardBrand) {},
            ),
            Expanded(
              child: SingleChildScrollView(
                child: Column(
                  children: [
                    CreditCardForm(
                      cardNumber: cardNumber,
                      expiryDate: expiryDate,
                      cardHolderName: cardHolderName,
                      cvvCode: cvvCode,
                      onCreditCardModelChange: onCreditCardModelChange,
                      themeColor: Colors.blue,
                      formKey: formKey,
                      cardNumberDecoration: const InputDecoration(
                        border: OutlineInputBorder(
                            borderSide: const BorderSide(color: Colors.white)),
                        labelText: 'Number',
                        hintText: 'xxxx xxxx xxxx xxxx',
                      ),
                      expiryDateDecoration: const InputDecoration(
                          border: OutlineInputBorder(),
                          labelText: 'Expired Date',
                          hintText: 'xx/xx'),
                      cvvCodeDecoration: const InputDecoration(
                          border: OutlineInputBorder(),
                          labelText: 'CVV',
                          hintText: 'xxx'),
                      cardHolderDecoration: const InputDecoration(
                        border: OutlineInputBorder(),
                        labelText: 'Card Holder',
                      ),
                    ),
                    ElevatedButton(
                      style: ElevatedButton.styleFrom(
                        shape: RoundedRectangleBorder(
                          borderRadius: BorderRadius.circular(8.0),
                        ),
                        primary: Color(0xff1b447b),
                      ),
                      child: Container(
                        margin: EdgeInsets.all(8.0),
                        child: const Text(
                          'Validate',
                          style: TextStyle(
                            color: Colors.white,
                            fontFamily: 'halter',
                            fontSize: 14,
                            package: 'flutter_credit_card',
                          ),
                        ),
                      ),
                      onPressed: () async {
                        if (formKey.currentState!.validate()) {
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
                                  content:
                                      Text("Uspjesno updateovan loyalty bonus"),
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
                                    content:
                                        Text("Uspjesno dodan loyalty bonus"),
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
                        } else {
                          print('inValid');
                        }
                      },
                    ),
                  ],
                ),
              ),
            )
          ],
        ),
      ),
    );
  }

  void onCreditCardModelChange(CreditCardModel creditCardModel) {
    setState(() {
      cardNumber = creditCardModel.cardNumber;
      expiryDate = creditCardModel.expiryDate;
      cardHolderName = creditCardModel.cardHolderName;
      cvvCode = creditCardModel.cvvCode;
      isCvvFocused = creditCardModel.isCvvFocused;
    });
  }
}
