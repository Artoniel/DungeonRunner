mergeInto(LibraryManager.library, {

  Hello: function () {
    window.alert("Hello, world!");
	console.log("Hello, world!");
  },
  
  GetPlayerData: function () {
	myGameInstance.SendMessage('Yandex', 'SetName', player.getName());
	myGameInstance.SendMessage('Yandex', 'SetPhoto', player.getPhoto("medium"));
  },
  RateGame: function () {
		ysdk.feedback.canReview()
			.then(({ value, reason }) => {
				if (value) {
					ysdk.feedback.requestReview()
						.then(({ feedbackSent }) => {
							console.log(feedbackSent);
						})
				} else {
					console.log(reason)
				}
			})
	},
	SaveExtern: function (data) {
		var dataString = UTF8ToString(data);
		var myobj = JSON.parse(dataString);
		player.setData(myobj);
	},
	LoadExtern: function () {
		player.getData().then(_data => {
			const myJSON = JSON.stringify(_data);
			myGameInstance.SendMessage('Progress', 'SetPlayerInfo', myJSON);
			
		});
	},
 
	SetToLeaderboard : function(value){
		console.log("SetToLeaderboard used!"); 
		ysdk.getLeaderboards()
		  .then(lb => {
			  
			lb.setLeaderboardScore('Score', value);
			
		  });

	},
	
	GetLang: function(){
		console.log("GetLang used!"); 
		var lang = ysdk.environment.i18n.lang;
		var bufferSize = lengthBytesUTF8(lang) + 1;
		var buffer = _malloc(bufferSize);
		stringToUTF8(lang, buffer, bufferSize);		
		return buffer;
	},
	
	ShowAdv: function(){
		ysdk.adv.showFullscreenAdv({
			callbacks: {
        onClose: function(wasShown) {
			console.log("-----------ADV WAS SHOWN-----------");
          // some action after close
        },
        onError: function(error) {
          // some action on error
        }
			}
		})
	},
	
	AddCoinsExtern: function(value){
		ysdk.adv.showRewardedVideo({
		callbacks: {
			onOpen: () => {
			  console.log('Video ad open.');
			},
			onRewarded: () => {
			  console.log('Rewarded!');
			  myGameInstance.SendMessage("CoinManager", "AddCoins", value);
			},
			onClose: () => {
			  console.log('Video ad closed.');
			}, 
			onError: (e) => {
			  console.log('Error while open video ad:', e);
			}
		}
	})
	},
	

});