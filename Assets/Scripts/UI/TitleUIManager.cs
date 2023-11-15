using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class TitleUIManager : MonoBehaviour
{
   

    //��ư ���� ����

    public Button btnSetting;
    public Button btnExit;
    public Button btnMin;
    public Button btnMax;
    public Button btnGameStart;
    public Button btnExitset;

    public GameObject pnlSetting;
    public Text txtSelect;

    //���� â ���� ����
    public Slider sldSoundFxVolume;
    public Slider sldBGMVolume;

    public Toggle toggleSoundFxMute;
    public Toggle toggleBGMMute;


    private bool isSoundFxMuted = false;
    private bool isBGMMuted = false;



    #region AddListner ����
    private void Start()
    {
        //��ư AddListner
        btnExit.onClick.AddListener(() =>
        {
            SoundManager.Instance.PlayButtonClickSound();
            UIManager.Instance.OnClickExit();
        });
        btnSetting.onClick.AddListener(() =>
        {
            SoundManager.Instance.PlayButtonClickSound();
            UIManager.Instance.ActivePnl(pnlSetting);
        });
        btnMin.onClick.AddListener(() =>
        {
            SoundManager.Instance.PlayButtonClickSound();
            OnClickDecrease();
        });
        btnMax.onClick.AddListener(() =>
        {
            SoundManager.Instance.PlayButtonClickSound();
            OnClickIncrease();
        });
        btnGameStart.onClick.AddListener(() =>
        {
            SoundManager.Instance.PlayGameStartSound();
            OnClickGameStart();
        });
        btnExitset.onClick.AddListener(() =>
        {
            SoundManager.Instance.PlayButtonClickSound();
            UIManager.Instance.ActivePnl(pnlSetting);
        });


        //����
        sldBGMVolume.onValueChanged.AddListener((value) =>
        {
            SoundManager.Instance.SetBGMVolume(value);

        });

        sldSoundFxVolume.onValueChanged.AddListener((value) =>
        {
            SoundManager.Instance.SetSoundFxVolume(value);

        });

        toggleBGMMute.onValueChanged.AddListener((isMuted) =>
        {
            SoundManager.Instance.MuteBGM(isMuted);

        });

        toggleSoundFxMute.onValueChanged.AddListener((isMuted) =>
        {
            SoundManager.Instance.MuteSoundFx(isMuted);

        });
    }

    #endregion

    #region TItle �� ��ư ��� �Լ�
    // Increase ��ư Ŭ���� value �� 1�� ����, �ִ� 5
    public void OnClickIncrease()
    {
        UIManager.Instance.value = int.Parse(txtSelect.text);

        if (UIManager.Instance.value < 5)
        {
            UIManager.Instance.value += 1;
            txtSelect.text = UIManager.Instance.value.ToString();
        }

       
    }

    // Decrease ��ư Ŭ���� value �� 1�� ����, �ּ� 2
    public void OnClickDecrease()
    {
        UIManager.Instance.value = int.Parse(txtSelect.text);

        if (UIManager.Instance.value > 2)
        {
            UIManager.Instance.value -= 1;
            txtSelect.text = UIManager.Instance.value.ToString();
        }
    }

    public void OnClickGameStart()
    {
        SceneManager.LoadScene("LakeScene");
        SoundManager.Instance.SwapBGMClip(1);
    }
    #endregion

    #region SETTING â ��� �Լ�

    //���� ���� �Լ�
    public void SetSoundFxVolume(float volume)
    {

        SoundManager.Instance.SetSoundFxVolume(volume);

        if (volume <= 0)
        {
            isSoundFxMuted = true;
            toggleSoundFxMute.isOn = true;
        }
        else
        {
            isSoundFxMuted = false;
            toggleSoundFxMute.isOn = false;
        }
    }

    public void SetBGMVolume(float volume)
    {
        Debug.Log("Setting BGM volume to: " + volume);
        SoundManager.Instance.SetBGMVolume(volume);

        if (volume <= 0)
        {
            isBGMMuted = true;
            toggleBGMMute.isOn = true;
        }
        else
        {
            isBGMMuted = false;
            toggleBGMMute.isOn = false;
        }
    }

    //���Ұ� �Լ�
    public void ToggleBGMMute(bool isMuted)
    {
        isBGMMuted = isMuted;

        // SoundManager�� ���Ұ� ��� ȣ��
        SoundManager.Instance.MuteBGM(isBGMMuted);
    }

    public void ToggleSoundFxMute(bool isMuted)
    {
        isSoundFxMuted = isMuted;

        // SoundManager�� ���Ұ� ��� ȣ��
        SoundManager.Instance.MuteSoundFx(isSoundFxMuted);

    }
    #endregion


}

