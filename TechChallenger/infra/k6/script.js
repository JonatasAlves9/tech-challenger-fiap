import http from "k6/http";
import { check } from "k6";
import { Rate } from "k6/metrics";

export let errorRate = new Rate("errors");

export default function () {
  var url =
    "http://a41e31c7bb4174d859b99b608a0c83c7-1382405691.us-east-1.elb.amazonaws.com/order";
  check(http.get(url), {
    "status is 200": (r) => r.status == 200,
  }) || errorRate.add(1);
}
