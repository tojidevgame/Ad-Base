using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Wolffun.Log;

namespace Wolffun.Ads
{

    public class CommonInterstitialAdController : CommonInterstitialAdController<AdFactoryBase, InterstitialModelBase>
    {
        protected override void CreateInterstitialAdModelBase()
        {
            _interstitialModel = _adFactoryBase.GetCommonForceAd();
            SetCallbackToAdModel(_interstitialModel);
        }
    }

    public abstract class CommonInterstitialAdController<TAdFactory, TInterstitialAdModel> : InterstitialAdControllerBase 
        where TAdFactory : AdFactoryBase
        where TInterstitialAdModel : InterstitialModelBase
    {
        [SerializeField] protected TAdFactory _adFactoryBase;

        protected TInterstitialAdModel _interstitialModel;

        public override void Request()
        {
            _interstitialModel.Request();
        }

        public override bool IsLoadedAd()
        {
            bool isLoadedAd = _interstitialModel.IsLoaded();
            CommonLog.Log(AdLog.GetLogString($"interstial ad loaded state: {isLoadedAd}"));

            return isLoadedAd;

        }

        protected override void ShowAd()
        {
            _interstitialModel?.Show();
        }
    }
}