import 'package:flutter/material.dart';

class EmptySection extends StatelessWidget {
  final String emptyImg, emptyMsg;

  const EmptySection(this.emptyImg, this.emptyMsg, { Key? key }) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return Center(
      child: Column(
        mainAxisAlignment: MainAxisAlignment.center,
        children: [
          Image(
            image: AssetImage(emptyImg),
            height: 150.0,
          ),
          Padding(
            padding: const EdgeInsets.only(top: 10.0),
            child: Text(
              emptyMsg,
              style: TextStyle(color: Colors.black),  
            ),
          )
        ],
      ),
    );
  }
}