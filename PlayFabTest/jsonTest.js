function cross(x,y){
    return x * y;
}

function jsonTest()
{
    var tester = {
        post : 
        [
            {
              "vimeoId": "12312312",
              "videoName": "테스트1",
              "videoUploadDate": "20221018182000",
              "videoLike": 5,
              "videoNumber": 1
            },
            {
              "vimeoId": "12312313",
              "videoName": "테스트2",
              "videoUploadDate": "20221019182000",
              "videoLike": 10,
              "videoNumber": 2
            },
            {
              "vimeoId": "12312314",
              "videoName": "테스트3",
              "videoUploadDate": "20221020182000",
              "videoLike": 2,
              "videoNumber": 3
            },
            {
              "vimeoId": "12312315",
              "videoName": "테스트4",
              "videoUploadDate": "20221021182000",
              "videoLike": 3,
              "videoNumber": 4
            },
            {
              "vimeoId": "12312316",
              "videoName": "테스트5",
              "videoUploadDate": "20221022182000",
              "videoLike": 17,
              "videoNumber": 5
            },
            {
              "vimeoId": "12312317",
              "videoName": "테스트6",
              "videoUploadDate": "20221023182000",
              "videoLike": 14,
              "videoNumber": 6
            }
          ]
    }
    return tester.post;
}

var data = jsonTest();

console.log(data);
let now_time = new Date();
let year = now_time.getFullYear();//년
let mon = (now_time.getMonth()+1); //월
let date = now_time.getDate(); //일
let hour = now_time.getHours(); //시간
let min = now_time.getMinutes(); //분
let sec = now_time.getSeconds(); //초
let milsec = now_time.getMilliseconds(); //밀리초

console.log("시간" + year + ":" + mon + ":" + date + ":" +hour+ ":"+ min + ":" +sec + ":" + milsec);


//CRUD 테스트

//data.push(); //객체 insert
//json 객체 배열에서 객체 제거
//data.shift(); //맨앞 요소 제거
//data.pop(); //맨뒤 요소 제거
//data.splice(1,1);//지정 인덱스의 요소 제거


var jsonPaser = [];

//데이터 배열 추가
function insertData(vimeo_id, user_id, user_name, video_name, video_upload_date, category_id_list)
{
    let json_index = jsonPaser.length;

    jsonPaser.push({
        "vimeo_id" : vimeo_id,
        "user_id" : user_id,
        "user_name" : user_name,
        "index" : json_index,
        "video_name": video_name,
        "video_upload_date":video_upload_date,
        "category_id_list" : category_id_list
    });
}

//데이터 5개 올리기
function input()
{
    for(i = 0; i < 5; i++)
    {
        let now_time = new Date();
        let year = now_time.getFullYear();//년
        let mon = (now_time.getMonth()+1); //월
        let date = now_time.getDate(); //일
        let hour = now_time.getHours(); //시간
        let min = now_time.getMinutes(); //분
        let sec = now_time.getSeconds(); //초
        let milsec = now_time.getMilliseconds(); //밀리초
        let currentTime = "" + year + ":" + mon + ":" + date + "::" + hour + ":" + min + ":" + sec;
        console.log(currentTime);
        let categoryList = [10,11,12];
        insertData(i, "hungame", "김영훈", "비디오넘버" + i , currentTime, categoryList);
    }
}


//3개씩 데이터 받아오기

console.log("------------------------");

//데이터 입력
input();
console.log(jsonPaser);

var array = [];

//특정 시간보다 작은 경우의 데이터 1개 받아오기
function searchData(data_time, data_index, get_member)
{
    let count = 0;

    //데이터 총 크기 인덱스
    let dataSize = jsonPaser.length - 1;
    for(i = dataSize; i >= 0; i--)
    {
        //시간 비교
        if(count >= get_member)
        {
            break;
        }
        
        if(parseInt(jsonPaser[i].video_upload_date) < data_time && jsonPaser[i].index < data_index)
        {
            array.push({
                "vimeo_id" : jsonPaser[i].vimeo_id,
                "user_id" : jsonPaser[i].user_id,
                "user_name" : jsonPaser[i].user_name,
                "index" : jsonPaser[i].index,
                "video_name": jsonPaser[i].video_name,
                "video_upload_date":jsonPaser[i].video_upload_date,
                "category_id_list" : jsonPaser[i].category_id_list
            });
            count++;
        }
    }
}

console.log("---------------------------");
searchData(20221021153018392, 3, 1);
console.log(array);


//json 내림차순, 오름차순 정렬

var sortJSON = function(data, key, type) {
  if (type == undefined) {
    type = "asc";
  }
  return data.sort(function(a, b) {
    var x = a[key];
    var y = b[key];
    if (type == "desc") {
      return x > y ? -1 : x < y ? 1 : 0;
    } else if (type == "asc") {
      return x < y ? -1 : x > y ? 1 : 0;
    }
  });
};

var testData = [{ key: 2 }, { key: 1 }, { key: 3 }, { key: 5 }, { key: 4 }];

console.log(testData);
// [ { key: 2 }, { key: 1 }, { key: 3 }, { key: 5 }, { key: 4 } ]

// 오름차순
console.log(sortJSON(testData, "key", "asc"));
// [ { key: 1 }, { key: 2 }, { key: 3 }, { key: 4 }, { key: 5 } ]

// 내림차순
console.log(sortJSON(testData, "key", "desc"));
