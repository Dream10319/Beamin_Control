using System.Collections.Generic;
using System.Collections;
using System;

namespace Beamin_Control
{

    public class Language_Class
    {

        public Dictionary<int, string> De = new Dictionary<int, string>();


        //public  enum Language { English, Korean }
        public Language_Class(string _Language)
        {

            switch (_Language)
            {
                case "English":
                    De.Add(9999, "en-US");
                    De.Add(9991, "next morning");
                    

                    #region Main Form
                    De.Add(01, "Seconds To Check For New Order");
                    De.Add(02, "Original App Version");
                    De.Add(03, "Checking For New Orders");

                    De.Add(100, "Are You Sure To Unblock ?");
                    De.Add(101, "Unblock");


                    De.Add(400, "Login");
                    De.Add(401, "Logout");
                    De.Add(500, "Web Settings");
                    De.Add(501, "New");
                    De.Add(502, "Completed");
                    #endregion

                    #region Availabilities Control


                    De.Add(402, "Temporarily Closed");
                    De.Add(403, "Open");

                    De.Add(700, "Please select a time to temporarily suspend");
                    De.Add(701, "30 minutes");
                    De.Add(702, "1 hour");
                    De.Add(703, "1 hour 30 minutes");
                    De.Add(704, "2 hours");
                    De.Add(705, "3 hours");
                    De.Add(706, "4 hours");

                    #endregion

                    #region Orders Control
                    De.Add(1000, "Can't Get New Orders, Orders Checker Stoped");
                    De.Add(1001, "Can't Get Orders Details");
                    De.Add(1002, "Are You Sure To Set This Order As Complete ?");
                    De.Add(1003, "Are You Sure To Set This Order As Cookie Complete ?");

                    De.Add(1100, "Order Rejection");
                    De.Add(1101, "Order Cancellation");
                    De.Add(1102, "Order Complete");
                    De.Add(1103, "Accept");

                    De.Add(1104, "Requests");
                    De.Add(1105, "Foods");
                    De.Add(1106, "Order Information");

                    De.Add(1107, "Amount To Receive");
                    De.Add(1108, "Delivery address");

                    De.Add(1109, "Phone No");
                    De.Add(1110, "Order number");
                    De.Add(1111, "Order Time");
                    De.Add(1112, "Store Information");

                    De.Add(1113, "Completion Time");
                    De.Add(1114, "Receipt Time");
                    De.Add(1115, "Delivery Minutes");
                    De.Add(1116, "Cancellation Time");
                    De.Add(1117, "Reasons For Cancellation");
                    De.Add(1118, "Order Complete Notification Sent");

                    De.Add(1119, "BAEMIN 1");

                    De.Add(1120, "Order Progress");
                    De.Add(1121, "Order Status");
                    De.Add(1122, "Rider Status");
                    De.Add(1123, "Date");
                    De.Add(1124, "Cookie Complete");



                    #endregion

                    #region Login

                    #region Login Messages
                    De.Add(2000, "Authorization Success");
                    De.Add(2001, "Need Mobile Authorization");
                    De.Add(2002, "Mobile Authorization");
                    De.Add(2003, "Are You Sure To Logout ?");
                    #endregion



                    #region Login Form
                    De.Add(2200, "Username");
                    De.Add(2201, "Password");
                    De.Add(2202, "Login");
                    De.Add(2203, "User Login");
                    #endregion

                    #region  Mobile Authorization Form
                    De.Add(2400, "Mobile Authorization");
                    De.Add(2401, "Mobile Number");
                    De.Add(2402, "Send Code");
                    De.Add(2403, "Code");
                    De.Add(2404, "Login");
                    #endregion


                    #endregion

                    #region Hardware Info Form
                    De.Add(4000, "Your Hardware Information");
                    De.Add(4001, "Operating System");
                    De.Add(4002, "Device Name");
                    De.Add(4003, "Mac Address");
                    De.Add(4004, "MotherBoard ID");
                    De.Add(4005, "Harddisk Serial");
                    De.Add(4006, "Apply");

                    De.Add(4007, "Mohamed's PC Information");
                    De.Add(4008, "Your Real PC Information");


                    #endregion

                    //De.Add(, );
                    //De.Add(, );
                    //De.Add(, );
                    //De.Add(, );

                    #region Beamin Web


                    #region Web Form
                    De.Add(20000, "Member ID ...");
                    De.Add(20001, "Member Name ...");

                    De.Add(20002, "Notice a word");
                    De.Add(20003, "Operation information");
                    De.Add(20004, "Menu / Option Management");
                    De.Add(20005, "Review management");
                    De.Add(20006, "Order History");
                    De.Add(20007, "Edit Store Menu");
                    De.Add(20008, "Boss Notice");
                    De.Add(20009, "A Word From The Boss");
                    De.Add(20010, "Menu Sold Out");
                    De.Add(20011, "Option out of stock");

                    #endregion

                    #region   Notice a word

                    De.Add(20012, "Write New");
                    De.Add(23000, "Upload directly to the app");

                    De.Add(23001, "* 3MB or less, only PNG/JPG/GIF can be uploaded.");
                    De.Add(23002, "* Animated GIF images cannot be registered.");
                    De.Add(23003, "Write");

                    De.Add(23004, "Images");
                    De.Add(23005, "of");


                    #endregion

                    #region Operation Information
                    De.Add(24000, "Opening hours");
                    De.Add(24001, "break time");
                    De.Add(24002, "Closed Days");
                    De.Add(24003, "Holiday Information");
                    De.Add(24004, "Temporaily Suspended Business");


                    De.Add(24005, "not set");
                    De.Add(24006, "Hours");
                    De.Add(24007, "holiday");
                    De.Add(24008, "Closed");

                    De.Add(24009, "Regular Holiday");
                    De.Add(24010, "Temporary Closure");

                    De.Add(24011, "Reasone");
                    De.Add(24012, "Clear");
                    De.Add(24013, "Change");


                    De.Add(24014, "first {0} of every month");
                    De.Add(24015, "second {0} of every month");
                    De.Add(24016, "third {0} of every month");
                    De.Add(24017, "forth {0} of every month");
                    De.Add(24018, "fifth {0} of every month");
                    De.Add(24019, "last {0} of every month");
                    De.Add(24020, "every {0}");

                    De.Add(24021, "first of every month");
                    De.Add(24022, "second of every month");
                    De.Add(24023, "third of every month");
                    De.Add(24024, "forth of every month");
                    De.Add(24025, "fifth of every month");
                    De.Add(24026, "last of every month");
                    De.Add(24027, "every week");


                    #region Operation Information Change Button
                    De.Add(25000, "Operation Hours Update");
                    De.Add(25001, "Everyday");
                    De.Add(25002, "Weekdays Weekend");
                    De.Add(25003, "By day");
                    De.Add(25004, "Change");

                    De.Add(25005, "Start");
                    De.Add(25006, "End");
                    De.Add(25007, "24 Hours");


                    De.Add(25050, "Server Error");
                    De.Add(25051, "Operation Hours Update Error");

                    #endregion


                    #region Break Time Change Button
                    De.Add(25100, "Break Time Update");
                    De.Add(251001, "Change");


                    De.Add(26001, "MONDAY");
                    De.Add(26002, "TUESDAY");
                    De.Add(26003, "WEDNESDAY");
                    De.Add(26004, "THURSDAY");
                    De.Add(26005, "FRIDAY");
                    De.Add(26006, "SATURDAY");
                    De.Add(26007, "SUNDAY");

                    De.Add(26008, "EVERYDAY");
                    De.Add(26009, "WEEKDAY");
                    De.Add(26010, "MONDAY To FRIDAY");

                    De.Add(26100, "Enable");

                    De.Add(26050, "Break Time Update Error");


                    #endregion

                    #region Close Days  Change Button

                    De.Add(28010, "Closed Days Update");
                    De.Add(28011, "Add regular holiday");
                    De.Add(28012, "Add temporary leave");
                    De.Add(28013, "Change");
                    De.Add(28014, "Holiday");
                    De.Add(28015, "Delete");
                    De.Add(28050, "Close Days Update Update Error");

                    #endregion


                    #region Holiday Information Change Button
                    De.Add(29000, "Holiday Information Update");
                    De.Add(29001, "Change");
                    De.Add(29050, " Holiday Information Update Update Error");

                    #endregion


                    #region Temporaily Suspend Business Change Button
                    De.Add(30000, "Temporaily Suspend Business Update");
                    De.Add(30001, "Temporaily Suspend Reason");
                    De.Add(30100, "Clear Temporaily Suspended Business");
                    De.Add(30101, "Would You Want To Clear The Temporaily Suspended Business");
                    #endregion


                    #endregion



                    #endregion

                    break;

                case "Korean":
                    De.Add(9999, "ko-KR");
                    De.Add(9991, "다음 날 오전");

                    #region 기본 양식
                    De.Add(01, "새 주문을 확인하는 데 걸리는 시간(초)");
                    De.Add(02, "원래 앱 버전");
                    De.Add(03, "신규 주문 확인 중");

                    De.Add(100, "차단을 해제하시겠습니까?");
                    De.Add(101, "차단 해제");


                    De.Add(400, "로그인");
                    De.Add(401, "로그아웃");
                    De.Add(500, "웹 설정");
                    De.Add(501, "새로 만들기");
                    De.Add(502, "완료");
                    #endregion

                    #region 가용성 제어


                    De.Add(402, "임시 휴업");
                    De.Add(403, "열기");

                    De.Add(700, "일시적으로 중단할 시간을 선택해주세요");
                    De.Add(701, "30분");
                    De.Add(702, "1시간");
                    De.Add(703, "1시간 30분");
                    De.Add(704, "2시간");
                    De.Add(705, "3시간");
                    De.Add(706, "4시간");

                    #endregion

                    #region 주문 관리
                    De.Add(1000, "새 주문을 받을 수 없습니다. 주문 확인기가 중지되었습니다.");
                    De.Add(1001, "주문 세부정보를 가져올 수 없습니다.");
                    De.Add(1002, "이 주문을 완료로 설정하시겠습니까?");
                    De.Add(1003, "이 주문을 쿠키 완료로 설정하시겠습니까?");

                    De.Add(1100, "주문 거부");
                    De.Add(1101, "주문 취소");
                    De.Add(1102, "주문 완료");
                    De.Add(1103, "수락");

                    De.Add(1104, "요청");
                    De.Add(1105, "식품");
                    De.Add(1106, "주문정보");

                    De.Add(1107, "받을 금액");
                    De.Add(1108, "배송주소");

                    De.Add(1109, "전화번호");
                    De.Add(1110, "주문번호");
                    De.Add(1111, "주문 시간");
                    De.Add(1112, "상점정보");

                    De.Add(1113, "완료 시간");
                    De.Add(1114, "수신시간");
                    De.Add(1115, "배달 시간");
                    De.Add(1116, "취소 시간");
                    De.Add(1117, "취소 사유");
                    De.Add(1118, "주문 완료 알림이 전송되었습니다.");
                    De.Add(1119, "배민 1");

                    De.Add(1120, "주문 진행 상황");
                    De.Add(1121, "주문 상태");
                    De.Add(1122, "라이더 상태");
                    De.Add(1123, "날짜");
                    De.Add(1124, "쿠키 완료");

                    #endregion

                    #region 지역 로그인

                    #region 로그인 메시지
                    De.Add(2000, "인증 성공");
                    De.Add(2001, "모바일 인증이 필요합니다");
                    De.Add(2002, "모바일 인증");
                    De.Add(2003, "로그아웃하시겠습니까?");
                    #endregion



                    #region 로그인 양식
                    De.Add(2200, "사용자 이름");
                    De.Add(2201, "비밀번호");
                    De.Add(2202, "로그인");
                    De.Add(2203, "사용자 로그인");
                    #endregion

                    #region 모바일 승인 양식
                    De.Add(2400, "모바일 인증");
                    De.Add(2401, "휴대폰번호");
                    De.Add(2402, "코드 보내기");
                    De.Add(2403, "코드");
                    De.Add(2404, "로그인");
                    #endregion


                    #endregion

                    #region 하드웨어 정보 양식
                    De.Add(4000, "하드웨어 정보");
                    De.Add(4001, "운영 체제");
                    De.Add(4002, "장치 이름");
                    De.Add(4003, "맥 주소");
                    De.Add(4004, "마더보드 ID");
                    De.Add(4005, "하드디스크 시리얼");
                    De.Add(4006, "적용");

                    De.Add(4007, "모하메드의 PC 정보");
                    De.Add(4008, "귀하의 실제 PC 정보");


                    #endregion


                    //---------
                    #region 비민 웹


                    #region 웹 양식
                    De.Add(20000, "회원ID ...");
                    De.Add(20001, "회원 이름 ...");

                    De.Add(20002, "단어 주목");
                    De.Add(20003, "작업정보");
                    De.Add(20004, "메뉴/옵션 관리");
                    De.Add(20005, "리뷰관리");
                    De.Add(20006, "주문내역");
                    De.Add(20007, "상점 메뉴 편집");
                    De.Add(20008, "상사 공지");
                    De.Add(20009, "사장으로부터의 한마디");
                    De.Add(20010, "메뉴 매진");
                    De.Add(20011, "옵션 품절");

                    #endregion

                    #region 한마디에 주목하세요

                    De.Add(20012, "새로 쓰기");
                    De.Add(23000, "앱에 직접 업로드");

                    De.Add(23001, "* 3MB 이하, PNG/JPG/GIF만 업로드할 수 있습니다.");
                    De.Add(23002, "* 애니메이션 GIF 이미지는 등록할 수 없습니다.");
                    De.Add(23003, "쓰기");

                    De.Add(23004, "이미지");
                    De.Add(23005, "of");


                    #endregion

                    #region 운영정보
                    De.Add(24000, "영업시간");
                    De.Add(24001, "휴식 시간");
                    De.Add(24002, "휴무일");
                    De.Add(24003, "휴일 정보");
                    De.Add(24004, "영업 일시 중단");


                    De.Add(24005, "설정되지 않음");
                    De.Add(24006, "시간");
                    De.Add(24007, "휴일");
                    De.Add(24008, "닫음");

                    De.Add(24009, "정기휴일");
                    De.Add(24010, "임시 폐쇄");

                    De.Add(24011, "이유");
                    De.Add(24012, "지우기");
                    De.Add(24013, "변경");


                    De.Add(24014, "매월 첫째 {0}");
                    De.Add(24015, "매월 두 번째 {0}");
                    De.Add(24016, "매월 세 번째 {0}");
                    De.Add(24017, "매월 {0}");
                    De.Add(24018, "매월 5번째 {0}");
                    De.Add(24019, "매월 마지막 {0}");
                    De.Add(24020, "{0}마다");

                    De.Add(24021, "매월 1일");
                    De.Add(24022, "매월 초");
                    De.Add(24023, "매월 3일");
                    De.Add(24024, "매월 4일");
                    De.Add(24025, "매월 5일");
                    De.Add(24026, "매월 말일");
                    De.Add(24027, "매주");


                    #region 운행정보 변경 버튼
                    De.Add(25000, "운영시간 업데이트");
                    De.Add(25001, "매일");
                    De.Add(25002, "주중 주말");
                    De.Add(25003, "요일별");
                    De.Add(25004, "변경");

                    De.Add(25005, "시작");
                    De.Add(25006, "종료");
                    De.Add(25007, "24시간");


                    De.Add(25050, "서버 오류");
                    De.Add(25051, "운영시간 업데이트 오류");

                    #endregion


                    #region 휴식 시간 변경 버튼
                    De.Add(25100, "휴식 시간 업데이트");
                    De.Add(251001, "변경");


                    De.Add(26001, "월요일");
                    De.Add(26002, "화요일");
                    De.Add(26003, "수요일");
                    De.Add(26004, "목요일");
                    De.Add(26005, "금요일");
                    De.Add(26006, "토요일");
                    De.Add(26007, "일요일");

                    De.Add(26008, "매일");
                    De.Add(26009, "평일");
                    De.Add(26010, "월요일부터 금요일까지");

                    De.Add(26100, "활성화");

                    De.Add(26050, "휴식 시간 업데이트 오류");


                    #endregion

                    #region 마감일 변경 버튼

                    De.Add(28010, "휴무일 업데이트");
                    De.Add(28011, "정기휴일 추가");
                    De.Add(28012, "임시 휴가 추가");
                    De.Add(28013, "변경");
                    De.Add(28014, "휴일");
                    De.Add(28015, "삭제");
                    De.Add(28050, "Close Days 업데이트 업데이트 오류");

                    #endregion


                    #region 공휴일 정보 변경 버튼
                    De.Add(29000, "휴일 정보 업데이트");
                    De.Add(29001, "변경");
                    De.Add(29050, " 공휴일 정보 업데이트 업데이트 오류");

                    #endregion


                    #region 사업 변경 버튼을 일시적으로 중단합니다
                    De.Add(30000, "업무 업데이트를 일시적으로 중단합니다");
                    De.Add(30001, "일시 정지 사유");
                    De.Add(30100, "일시정지 영업 해제");
                    De.Add(30101, "일시정지된 영업을 청산하시겠습니까?");
                    #endregion


                    #endregion
                    #endregion

                    break;
            }

        }

        public static explicit operator Language_Class(string v)
        {
            throw new NotImplementedException();
        }

        //public string R (string )




    }
}
