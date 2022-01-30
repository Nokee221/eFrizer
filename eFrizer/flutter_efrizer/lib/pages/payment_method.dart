import 'package:flutter/material.dart';
import 'package:flutter_credit_card/credit_card_widget.dart';
import 'package:flutter_login/models/credit_card/credit_card.dart';
import 'package:flutter_login/pages/new_credit_card.dart';
import 'package:flutter_login/provider/dark_theme_provider.dart';
import 'package:flutter_login/services/api_service.dart';
import 'package:google_fonts/google_fonts.dart';
import 'package:provider/provider.dart';

class MyPaymentPage extends StatefulWidget {
  const MyPaymentPage({Key? key}) : super(key: key);

  @override
  _MyPaymentPageState createState() => _MyPaymentPageState();
}

class _MyPaymentPageState extends State<MyPaymentPage> {
  var deleteResult = null;
  Future<void> deleteCard(cardId) async {
    deleteResult = await APIService.delete("CreditCard", cardId.toString());
  }

  @override
  Widget build(BuildContext context) {
    final themeChange = Provider.of<DarkThemeProvider>(context);

    return Scaffold(
      appBar: AppBar(
        leading: BackButton(color: Colors.blue),
        centerTitle: true,
        title: Text(
          "My Payment Methods",
          style: GoogleFonts.pacifico(
              color: themeChange.darkTheme ? Colors.white : Colors.black),
        ),
        backgroundColor: Colors.transparent,
        elevation: 0,
      ),
      body: Column(
        children: <Widget>[
          Padding(
            padding: const EdgeInsets.all(8.0),
            child: Container(
              width: double.infinity,
              height: 290,
              child: cardWidget(),
            ),
          ),
          Padding(
            padding: const EdgeInsets.only(top: 210),
            child: Center(
              child: RaisedButton(
                color: Colors.blue,
                onPressed: () {
                  Navigator.of(context).push(
                    MaterialPageRoute(
                      builder: (BuildContext context) => NewCreditCardPage(),
                    ),
                  );
                },
                child: Padding(
                  padding: EdgeInsets.symmetric(horizontal: 30),
                  child: Text(
                    "Add new card",
                    style: TextStyle(
                      color: Colors.white,
                      fontWeight: FontWeight.bold,
                      fontSize: 14.0,
                    ),
                  ),
                ),
              ),
            ),
          )
        ],
      ),
    );
  }

  Widget cardWidget() {
    return FutureBuilder<List<CreditCard>>(
        future: getCreditCards(),
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
                scrollDirection: Axis.horizontal,
                physics: ScrollPhysics(),
                children:
                    snapshot.data!.map((e) => _MyCreditCardWidget(e)).toList(),
              );
            }
          }
        });
  }

  Future<List<CreditCard>> getCreditCards() async {
    var card = await APIService.get('CreditCard', null);
    if (card != null) {
      return card.map((i) => CreditCard.fromJson(i)).toList();
    } else {
      return List.empty();
    }
  }

  Widget _MyCreditCardWidget(card) => Container(
        width: 360,
        margin: const EdgeInsets.all(10),
        decoration: BoxDecoration(
          borderRadius: BorderRadius.circular(16),
          color: Colors.blue[200],
          boxShadow: [
            BoxShadow(
              color: Colors.blue,
              blurRadius: 10.0,
              spreadRadius: 1.0,
              offset: Offset(4.0, 4.0),
            ),
          ],
        ),
        child: Row(
          children: [
            Flexible(
              child: Column(
                children: [
                  Row(
                    mainAxisAlignment: MainAxisAlignment.spaceBetween,
                    children: [
                      Flexible(
                        child: Text(
                          "",
                          maxLines: 1,
                          overflow: TextOverflow.ellipsis,
                          style: TextStyle(
                            fontWeight: FontWeight.bold,
                            fontSize: 14,
                          ),
                        ),
                      ),
                      Material(
                        color: Colors.transparent,
                        child: InkWell(
                          borderRadius: BorderRadius.circular(50.0),
                          onTap: () async {
                            await deleteCard(card.creditCardId);
                            if (deleteResult != null) {
                              Widget okButton = TextButton(
                                child: Text("OK"),
                                onPressed: () {
                                  Navigator.pop(context);
                                },
                              );
                              AlertDialog alert = AlertDialog(
                                title: Text("Success"),
                                content: Text("Successfully deleted credit card!"),
                                actions: [
                                  okButton,
                                ],
                              );
                              showDialog(
                                  context: context,
                                  builder: (BuildContext context) {
                                    return alert;
                                  });
                            } else {
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
                          },
                          child: Container(
                            height: 50,
                            width: 50,
                            child: Icon(
                              Icons.delete,
                              color: Colors.red,
                              size: 22,
                            ),
                          ),
                        ),
                      ),
                    ],
                  ),
                  CreditCardWidget(
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
                ],
              ),
            ),
          ],
        ),
      );
}
