import 'package:flutter/foundation.dart';
import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:flutter/painting.dart';
import 'package:flutter_login/models/application_user/application_user.dart';
import 'package:flutter_login/models/hairsalon_service/hairsalon_service.dart';
import 'package:flutter_login/models/hairsalon_service/harisalon_service_search_request.dart';
import 'package:flutter_login/models/reservation/reservation_insert_request.dart';
import 'package:flutter_login/models/service.dart';
import 'package:flutter_login/pages/payment.dart';
import 'package:date_time_picker/date_time_picker.dart';
import 'package:flutter_login/provider/dark_theme_provider.dart';
import 'package:flutter_login/services/api_service.dart';
import 'package:flutter_login/widget/back_button.dart';
import 'package:flutter_login/widget/my_text_field.dart';
import 'package:flutter_login/widget/top_container.dart';
import 'package:intl/intl.dart';
import 'package:provider/provider.dart';
import 'package:intl/intl.dart';
import 'package:intl/date_symbol_data_local.dart';



class NewReservation extends StatefulWidget {
  final ApplicationUser user;
  final int applicationUserId;
  final DateTime reservationDate;
  final DateTime endDate;
  final int hairdressedid;
  final int hairsalonId;
  const NewReservation(this.user, this.reservationDate, this.hairdressedid , this.endDate , this.applicationUserId, this.hairsalonId ,{Key? key}) : super(key: key);

  @override
  _NewReservationState createState() => _NewReservationState(user, reservationDate, hairdressedid, applicationUserId, hairsalonId);
}

class _NewReservationState extends State<NewReservation> {
  final ApplicationUser user;

  final int applicationUserId;
  late DateTime reservationDate;
  late DateTime endDate;
  final int hairdresserId;
  final int hairsalonId;
  
  HairSalonService? _service = null;
  List<DropdownMenuItem<HairSalonService>> items = [];

  _NewReservationState(this.user ,this.reservationDate, this.hairdresserId, this.applicationUserId, this.hairsalonId);

  TextEditingController dateinput = TextEditingController();
  TextEditingController totime = TextEditingController();
  TextEditingController endtime = TextEditingController();
  TextEditingController txtPrice = TextEditingController();
  TextEditingController txtPriceWith$ = TextEditingController();

  var request = null;
  @override
  void initState(){
    super.initState();
    dateinput.text = reservationDate.toString();
    totime.text = reservationDate.hour.toString() + ":" + reservationDate.minute.toString();
    txtPrice.text = "";

    request = HairSalonServiceSearchRequest(hairsalonId: hairsalonId);
    initializeDateFormatting('ECT');
  }
  
  @override
  Widget build(BuildContext context) {
    final themeChange = Provider.of<DarkThemeProvider>(context);
    double width = MediaQuery.of(context).size.width;
    final icon = CupertinoIcons.moon_stars;
    //supportedLocales: [Locale('en', 'US')];

    return Scaffold(
      body: SafeArea(
        child: ListView(
          children: <Widget>[
            TopContainer(
              padding: EdgeInsets.fromLTRB(20, 20, 20, 40),
              width: width,
              child: Column(
                children: <Widget>[
                  MyBackButton(),
                  const SizedBox(
                    height: 30,
                  ),
                  Row(
                    mainAxisAlignment: MainAxisAlignment.start,
                    children:  const <Widget>[
                       Text(
                        "Create new Reservation",
                        style:  TextStyle(
                          fontSize: 30.0,
                          fontWeight: FontWeight.w700,
                        ),
                      ),
                    ],
                  ),
                  const SizedBox(
                    height: 20,
                  ),
                  Container(
                    child: Column(
                      crossAxisAlignment: CrossAxisAlignment.start,
                      children: <Widget>[
                        DateTimePicker(
                          
                          type: DateTimePickerType.dateTime,
                          dateMask: 'dd.MM.yyyy',
                          controller: dateinput,
                          icon: Icon(Icons.calendar_today),
                          firstDate: DateTime(2020),
                          lastDate: DateTime(2100),
                          dateLabelText: 'Date',
                          //use24HourFormat: false,
                          onChanged: (val) => setState(() {
                            reservationDate = DateTime.parse(val);
                            //dateinput.text = reservationDate.day.toString() + "." + reservationDate.month.toString() + "." + reservationDate.year.toString();
                            totime.text = reservationDate.hour.toString() + ":" + reservationDate.minute.toString();
                            
                          
                            
                          }),
                          onSaved: (val) => setState(() {
                            reservationDate = DateTime.parse(val.toString());
                            //dateinput.text = reservationDate.day.toString() + "." + reservationDate.month.toString() + "." + reservationDate.year.toString();
                            totime.text = reservationDate.hour.toString() + ":" + reservationDate.minute.toString();

                            
                          }),
                        ),
                        SizedBox(height: 15),
                        dropDownWidget(),
                      ],
                    ),
                  )
                ],
              ),
            ),
            const SizedBox(height: 25),
            Expanded(
              child: SingleChildScrollView(
                padding: const EdgeInsets.symmetric(horizontal: 20),
                child: Column(
                  children: <Widget>[
                    Row(
                      mainAxisAlignment: MainAxisAlignment.spaceBetween,
                      children: <Widget>[
                        Expanded(
                          child: TextField(
                            controller: totime,
                            decoration: const InputDecoration(
                              icon: Icon(Icons.timer),
                              labelText: "Start time",
                            ),
                            readOnly: true,
                          ),
                        ),
                        SizedBox(width: 40),
                        Expanded(
                          child: TextField(
                            controller: endtime,
                            decoration: const InputDecoration(
                              labelText: 'End Time',
                            ),
                            readOnly: true,
                          ),
                        ),
                      ],
                    ),
                    SizedBox(height: 20),
                    Row(
                      children: <Widget>[
                      Container(
                      width: 100,
                      child: TextField(
                      controller: txtPriceWith$,
                      style: TextStyle(color: themeChange.darkTheme ? Colors.white : Colors.black),
                      minLines: 1,
                      maxLines: 1,
                      decoration: InputDecoration(
                        icon: Icon(Icons.price_check_sharp),
                        labelText: "Price",
                        labelStyle: TextStyle(
                          color: themeChange.darkTheme ? Colors.white : Colors.black,
                        ),
                        focusedBorder: UnderlineInputBorder(borderSide: BorderSide(color: themeChange.darkTheme ? Colors.white : Colors.black, width: 2.0)),
                        border: UnderlineInputBorder(borderSide: BorderSide(color: Colors.grey, width: 2.0)),
                      ),
                      ),
                      ),
                      
                      ],
                    ),
                    
                    const SizedBox(height: 70),
                  ],
                ),
              ),
            ),
            Container(
              height: 50,
              width: 160.0,
              padding: EdgeInsets.all(2),
              margin: EdgeInsets.all(20),
              decoration: BoxDecoration(
                color: Colors.blue,
                borderRadius: BorderRadius.circular(15),
              ),
              child: FlatButton(


                onPressed: (){

                  
                    var request = null;
                    var dateFormatted = DateFormat("yyyy-MM-dd HH:mm:ss").format(reservationDate);
                    var enddateFormatted = DateFormat("yyyy-MM-dd HH:mm:ss").format(endDate);
                    

                    request = ReservationInsertRequest(hairDresserId: hairdresserId, serviceId: _service!.hairSalonServiceId, clientId: applicationUserId, to: enddateFormatted , from: dateFormatted);
                    
                    Navigator.of(context).push(
                            MaterialPageRoute(
                                builder: (context) => Payment(user , request)),
                          );

                  
                },
                child: const Center(
                  child: Text(
                    "Make a reservation",
                    style: TextStyle(
                      color: Colors.white,
                      fontWeight: FontWeight.w700,
                      fontSize: 16,
                    ),
                  ),
                ),
              ),
            )
          ],
        ),
      ),
    );
  }

  Widget dropDownWidget() {
    return FutureBuilder<List<HairSalonService>>(
        future: getServices(_service, request),
        builder: (BuildContext context,
            AsyncSnapshot<List<HairSalonService>> snapshot) {
          if (snapshot.connectionState == ConnectionState.waiting) {
            return Center(
              child: Text('Loading...'),
            );
          }
          else {
            if (snapshot.hasError) {
              return Center(
                child: Text('${snapshot.error}'),
              );
            }
            else {
              return Padding(
                padding: EdgeInsets.fromLTRB(30, 10, 30, 10),
                child: Container(
                  padding: const EdgeInsets.all(8.0),
                  decoration: BoxDecoration(
                    borderRadius: BorderRadius.circular(10.0),
                    color: Colors.blue,
                    border: Border.all(),
                  ),
                  child: DropdownButtonHideUnderline(
                    child: DropdownButton<HairSalonService>(
                      hint: Text('Service'),
                      isExpanded: true,
                      dropdownColor: Colors.blue[300],
                      items: items,
                      onChanged: (newVal) {
                        setState(() {
                            _service = newVal as HairSalonService;

                            txtPrice.text = _service!.price.toString();
                            String pricee = _service!.price.toString();
                            txtPriceWith$.text = _service!.price.toString() + "KM";

                            DateTime endTimeee = reservationDate;
                            endDate = endTimeee.add(Duration(minutes: _service!.timeMin));
                            
                            endtime.text = endDate.hour.toString() + ":" + endDate.minute.toString();
                            print(endDate);
                        });
                      },
                      value: _service,
                    ),
                  ),
                )
              );
            }
          }
        });
  }

  Future<List<HairSalonService>> getServices(HairSalonService? selectedItem, req) async {
    Map<String, String>? queryParams = null;
    if (req != null && queryParams != "")
      queryParams = {'HairSalonId': req.hairsalonId.toString()};

    var vrsteProizvoda = await APIService.get('HairSalonService', queryParams);
    var vrsteProizvodaList = vrsteProizvoda!.map((i) => HairSalonService.fromJson(i)).toList();

    items = vrsteProizvodaList.map((item) {
      return DropdownMenuItem<HairSalonService>(
        child: Text(item.serviceName.toString(
          
        )),
        value: item,
      );
    }).toList();

      if (selectedItem != null && selectedItem.hairSalonServiceId != 0)
      _service = vrsteProizvodaList.where((element) => element.hairSalonServiceId == selectedItem.hairSalonServiceId).first;
        return vrsteProizvodaList;
   }

}