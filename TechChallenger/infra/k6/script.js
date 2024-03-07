import http from "k6/http";
import { check } from "k6";
import { Rate } from "k6/metrics";

export let errorRate = new Rate("errors");

export default function () {
  var url =
    "http://af8563dcb1efe464db80233aa8e3ccb2-60524262.us-east-1.elb.amazonaws.com/order";
  check(http.get(url), {
    "status is 200": (r) => r.status == 200,
  }) || errorRate.add(1);
}

