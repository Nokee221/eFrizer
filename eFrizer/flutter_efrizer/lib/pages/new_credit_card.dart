import 'package:flutter/material.dart';
import 'package:flutter_credit_card/credit_card_form.dart';
import 'package:flutter_credit_card/credit_card_model.dart';
import 'package:flutter_credit_card/credit_card_widget.dart';
import 'package:flutter_login/models/application_user/application_user.dart';
import 'package:flutter_login/models/credit_card/credit_card_insert_request.dart';
import 'package:flutter_login/pages/home_page.dart';
import 'package:flutter_login/pages/profile_page.dart';
import 'package:flutter_login/provider/dark_theme_provider.dart';
import 'package:flutter_login/services/api_service.dart';
import 'package:google_fonts/google_fonts.dart';
import 'package:provider/provider.dart';

class NewCreditCardPage extends StatefulWidget {
  final ApplicationUser user;
  const NewCreditCardPage(this.user, {Key? key}) : super(key: key);

  @override
  _NewCreditCardPageState createState() => _NewCreditCardPageState(user);
}

class _NewCreditCardPageState extends State<NewCreditCardPage> {
  final ApplicationUser user;
  _NewCreditCardPageState(this.user);

  String cardNumber = '';
  String expiryDate = '';
  String cardHolderName = '';
  String cvvCode = '';
  bool isCvvFocused = false;

  final GlobalKey<FormState> formKey = GlobalKey<FormState>();

  var result = null;
  Future<void> putCreditCard(String cardNumber, String cardHolderName,
      String expiryDate, String cvvCode) async {
    var req = new CreditCardInsertRequest(
        clientId: user.applicationUserId,
        cardName: cardNumber,
        cardHolderName: cardHolderName,
        expiryDate: expiryDate,
        cvvCode: cvvCode);
    result = APIService.post("CreditCard", req);
  }

  @override
  Widget build(BuildContext context) {
    final themeChange = Provider.of<DarkThemeProvider>(context);

    return Scaffold(
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
                          'Validate and Add',
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
                          await putCreditCard(
                              cardNumber, cardHolderName, expiryDate, cvvCode);
                          if (result != null) {
                            Widget okButton = TextButton(
                              child: Text("OK"),
                              onPressed: () {
                                Navigator.push(
                                    context,
                                    MaterialPageRoute(
                                        builder: (context) =>
                                            HomePage(user)));
                              },
                            );
                            AlertDialog alert = AlertDialog(
                              title: Text("Success"),
                              content: Text("Successfully added new credit card"),
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
