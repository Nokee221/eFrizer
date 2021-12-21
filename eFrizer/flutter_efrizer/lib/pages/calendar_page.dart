import 'dart:math';
import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:flutter_custom_clippers/flutter_custom_clippers.dart';
import 'package:flutter_login/models/reservation/reservation.dart';
import 'package:flutter_login/models/reservation/reservation_search_request.dart';
import 'package:flutter_login/pages/payment.dart';
import 'package:flutter_login/services/api_service.dart';
import 'package:table_calendar/table_calendar.dart';
import 'package:intl/intl.dart';

import 'new_reservation.dart';

class CalendarPage extends StatefulWidget {
  final int hairdresserId;
  CalendarPage(this.hairdresserId, {Key? key}) : super(key: key);

  @override
  _CalendarPageState createState() => _CalendarPageState(hairdresserId);
}

class _CalendarPageState extends State<CalendarPage> {
  final int hairdresserId;
  final icon = CupertinoIcons.moon_stars;

  DateTime _dateTime = DateTime.now();
  DateTime focusedDay = DateTime.now();

  var request = null;
  @override
  void initState() {
    super.initState();

    request = ReservationSearchRequest(hairdresserId: hairdresserId, day: _dateTime.day , month: _dateTime.month);
  }

  //CalendarController controller = new CalendarController();
  CalendarFormat format = CalendarFormat.week;

  _CalendarPageState(this.hairdresserId);

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
      body: SafeArea(
        child: Padding(
          padding: const EdgeInsets.fromLTRB(
            20,
            20,
            20,
            0,
          ),
          child: Column(
            children: <Widget>[
              Row(
                mainAxisAlignment: MainAxisAlignment.spaceBetween,
                children: <Widget>[
                  Text(
                    "${_dateTime.day}.${_dateTime.month}.${_dateTime.year}",
                    style: const TextStyle(
                      fontSize: 30.0,
                      fontWeight: FontWeight.w700,
                    ),
                  ),
                  Container(
                    height: 40.0,
                    width: 160.0,
                    decoration: BoxDecoration(
                      color: Colors.blue,
                      borderRadius: BorderRadius.circular(15),
                    ),
                    child: FlatButton(
                      onPressed: () {
                        Navigator.of(context).push(
                          MaterialPageRoute(
                              builder: (context) => NewReservation(_dateTime, hairdresserId, _dateTime)),
                        );
                      },
                      child: const Center(
                        child: Text(
                          "Add Reservation",
                          style: TextStyle(
                            color: Colors.white,
                            fontWeight: FontWeight.w700,
                            fontSize: 16,
                          ),
                        ),
                      ),
                    ),
                  ),
                ],
              ),
              SizedBox(height: 10),
              Row(
                mainAxisAlignment: MainAxisAlignment.start,
                children: const <Widget>[
                  Text(
                    "Current date",
                    style: TextStyle(
                      fontSize: 18.0,
                      color: Colors.grey,
                      fontWeight: FontWeight.w400,
                    ),
                  ),
                ],
              ),
              SizedBox(height: 30),
              TableCalendar(
                focusedDay: DateTime.now(),
                firstDay: DateTime(2020),
                lastDay: DateTime(2030),
                calendarFormat: format,
                onFormatChanged: (CalendarFormat _format) {
                  setState(() {
                    format = _format;
                  });
                },
                startingDayOfWeek: StartingDayOfWeek.sunday,
                daysOfWeekVisible: true,
                onDaySelected: (DateTime selectDay, DateTime focusDay) {
                  setState(() {
                    _dateTime = selectDay;
                    focusDay = focusDay;
                    request = ReservationSearchRequest(hairdresserId: hairdresserId, day: selectDay.day , month: selectDay.month);
                  });
                },
                selectedDayPredicate: (DateTime date) {
                  return isSameDay(_dateTime, date);
                },
                //Calendar style
                calendarStyle: const CalendarStyle(
                  isTodayHighlighted: true,
                  selectedDecoration: BoxDecoration(
                    color: Colors.blue,
                    shape: BoxShape.circle,
                  ),
                  selectedTextStyle: TextStyle(color: Colors.white),
                  todayDecoration: BoxDecoration(
                    color: Colors.grey,
                    shape: BoxShape.circle,
                  ),
                ),
                headerStyle: const HeaderStyle(
                  formatButtonVisible: false,
                  titleCentered: true,
                  formatButtonShowsNext: false,
                ),
              ),
              const Text(
                "-------------------------------------------------------------------------------------",
                style: TextStyle(color: Colors.grey),
              ),
              SizedBox(height: 5),
              Expanded(child: widgetReservation())
            ],
          ),
        ),
      ),
    );
  }

  Widget widgetReservation() {
    return FutureBuilder<List<Reservation>>(
        future: getReservaion(request),
        builder:
            (BuildContext context, AsyncSnapshot<List<Reservation>> snapshot) {
          if (snapshot.connectionState == ConnectionState.waiting) {
            return const Center(
              child: Text('Loading...'),
            );
          } else {
            if (snapshot.hasError) {
              return Center(
                child: Text('${snapshot.error}'),
              );
            } else {
              return ListView(
                children:
                    snapshot.data!.map((e) => ReservationWidget(e)).toList(),
              );
            }
          }
        });
  }

  Future<List<Reservation>> getReservaion(req) async {
    Map<String, String>? queryParams = null;
    if (req != null && queryParams != "")
      queryParams = {'HairDresserId': req.hairdresserId.toString(), 'Day': req.day.toString(), 'Month': req.month.toString()};

    var hairdresser = await APIService.get('Reservation', queryParams);
    return hairdresser!.map((i) => Reservation.fromJson(i)).toList();
  }

  Widget ReservationWidget(reservation) => Container(
        height: 80,
        width: 80,
        margin: const EdgeInsets.symmetric(horizontal: 20, vertical: 10),
        decoration: BoxDecoration(color: Colors.blueGrey[100], boxShadow: [
          BoxShadow(
              color: Colors.black.withOpacity(0.03),
              offset: Offset(0, 9),
              blurRadius: 20,
              spreadRadius: 1)
        ]),
        child: Row(
          children: [
            Container(
              margin: const EdgeInsets.symmetric(horizontal: 20),
              height: 25,
              width: 25,
              decoration: BoxDecoration(
                  color: Colors.white,
                  shape: BoxShape.circle,
                  border: Border.all(color: Colors.red, width: 4)),
            ),
            Column(
              crossAxisAlignment: CrossAxisAlignment.start,
              mainAxisAlignment: MainAxisAlignment.center,
              children: [
                const Text(
                  "Reservated",
                  style: TextStyle(
                    color: Colors.black,
                    fontSize: 18,
                  ),
                ),
                Text(
                  "To: " + reservation.To.toString(),
                  style: const TextStyle(
                    color: Colors.grey,
                    fontSize: 18,
                    fontWeight: FontWeight.bold
                  ),
                ),
              ],
            ),
            Expanded(
              child: Container(),
            ),
            Container(height: 80, width: 5, color: Colors.red)
          ],
        ),
      );
}
