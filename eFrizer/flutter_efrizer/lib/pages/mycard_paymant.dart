import 'dart:ffi';
import 'dart:math';

import 'package:flutter/material.dart';
import 'package:flutter_credit_card/credit_card_widget.dart';
import 'package:flutter_login/models/credit_card/credit_card.dart';
import 'package:flutter_login/models/credit_card/credit_card_search_request.dart';
import 'package:flutter_login/models/reservation/reservation_insert_request.dart';
import 'package:flutter_login/provider/dark_theme_provider.dart';
import 'package:flutter_login/services/api_service.dart';
import 'package:google_fonts/google_fonts.dart';
import 'package:provider/provider.dart';

class MyCardPayReservationPage extends StatefulWidget {
  final ReservationInsertRequest request;
  const MyCardPayReservationPage(this.request, {Key? key}) : super(key: key);

  @override
  _MyCardPayReservationPageState createState() =>
      _MyCardPayReservationPageState(request);
}

class _MyCardPayReservationPageState extends State<MyCardPayReservationPage> {
  final ReservationInsertRequest request;
  _MyCardPayReservationPageState(this.request);

  var req = null;
  @override
  void initState() {
    // TODO: implement initState

    req = CreditCardSearchRequest(clientId: request.clientId);
    super.initState();
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
        onTap: () {},
        child: CreditCardWidget(
          cardBgColor: Colors.primaries[Random().nextInt(Colors.primaries.length)],
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
