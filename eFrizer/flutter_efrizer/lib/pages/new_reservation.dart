import 'package:flutter/foundation.dart';
import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:flutter/painting.dart';
import 'package:flutter_login/models/reservation/reservation_insert_request.dart';
import 'package:flutter_login/models/service.dart';
import 'package:flutter_login/pages/payment.dart';
import 'package:date_time_picker/date_time_picker.dart';
import 'package:flutter_login/services/api_service.dart';
import 'package:flutter_login/widget/back_button.dart';
import 'package:flutter_login/widget/my_text_field.dart';
import 'package:flutter_login/widget/top_container.dart';
import 'package:intl/intl.dart';



class NewReservation extends StatefulWidget {
  final DateTime reservationDate;
  final DateTime endDate;
  final int hairdressedid;
  const NewReservation(this.reservationDate, this.hairdressedid , this.endDate , {Key? key}) : super(key: key);

  @override
  _NewReservationState createState() => _NewReservationState(reservationDate, hairdressedid);
}

class _NewReservationState extends State<NewReservation> {
  late DateTime reservationDate;
  late DateTime endDate;
  final int hairdresserId;
  
  Service? _service = null;
  List<DropdownMenuItem<Service>> items = [];

  _NewReservationState(this.reservationDate, this.hairdresserId);

  TextEditingController dateinput = TextEditingController();
  TextEditingController totime = TextEditingController();
  TextEditingController endtime = TextEditingController();
  TextEditingController txtPrice = TextEditingController();

  @override
  void initState(){
    super.initState();
    dateinput.text = reservationDate.toString();
    totime.text = reservationDate.hour.toString() + ":" + reservationDate.minute.toString();
    txtPrice.text = "";
  }
  
  @override
  Widget build(BuildContext context) {
    
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
                        dropDownWidget(),
                        SizedBox(height: 10),
                        DateTimePicker(
                          type: DateTimePickerType.dateTime,
                          dateMask: 'dd.MM.yyyy - hh:mm a',
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
                      controller: txtPrice,
                      style: TextStyle(color: Colors.black87),
                      minLines: 1,
                      maxLines: 1,
                      decoration: InputDecoration(
                        icon: Icon(Icons.price_check_sharp),
                        labelText: "Price",
                        labelStyle: TextStyle(
                          color: Colors.black45,
                        ),
                        focusedBorder: UnderlineInputBorder(borderSide: BorderSide(color: Colors.black, width: 2.0)),
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
                  

                  request = ReservationInsertRequest(hairDresserId: hairdresserId, serviceId: _service!.ServiceId, clientId: 7, to: dateFormatted , from: enddateFormatted);
                  
                  Navigator.of(context).push(
                          MaterialPageRoute(
                              builder: (context) => Payment(request)),
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
    return FutureBuilder<List<Service>>(
        future: getServices(_service),
        builder: (BuildContext context,
            AsyncSnapshot<List<Service>> snapshot) {
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
                    child: DropdownButton<Service>(
                      hint: Text('Service'),
                      isExpanded: true,
                      dropdownColor: Colors.blue[300],
                      items: items,
                      onChanged: (newVal) {
                        setState(() {
                            _service = newVal as Service;

                            txtPrice.text = _service!.Price.toString();

                            DateTime endTimeee = reservationDate;
                            endDate = endTimeee.add(Duration(minutes: _service!.Price));
                            
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

  Future<List<Service>> getServices(Service? selectedItem) async {
    var vrsteProizvoda = await APIService.get('Service', null);
    var vrsteProizvodaList = vrsteProizvoda!.map((i) => Service.fromJson(i)).toList();

    items = vrsteProizvodaList.map((item) {
      return DropdownMenuItem<Service>(
        child: Text(item.Name.toString(
          
        )),
        value: item,
      );
    }).toList();

      if (selectedItem != null && selectedItem.ServiceId != 0)
      _service = vrsteProizvodaList.where((element) => element.ServiceId == selectedItem.ServiceId).first;
        return vrsteProizvodaList;
   }

}