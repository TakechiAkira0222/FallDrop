using Photon.Pun;
using Photon.Realtime;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using TakechiPunCallbacks.InformationDisplay;

namespace TakechiPunCallbacks.PunFunction
{
    public class TakechiPunFunction : TakechiPunInformationDisplay
    {
        /// <summary>
        /// �n���ꂽ�������w�莞�Ԍ�Ɏ��s����
        /// </summary>
        /// <param name="waitTime">�x������[�~���b]</param>
        /// <param name="action">���s����������</param>
        /// <returns></returns>
        protected IEnumerator DelayMethod(float waitTime, Action action)
        {
            yield return new WaitForSeconds(waitTime);
            action();
        }

        #region SettingsClass

        /// <summary>
        /// ���[����{�ݒ�̒�`
        /// </summary>
        /// <param name="maxPlayers"> �ő�l�� </param>
        /// <param name="isVisible"> ���J or ����J </param>
        /// <param name="isOpen"> ���o���@</param>
        /// <returns></returns>
        protected RoomOptions SetRoomOptions(int maxPlayers, bool isVisible, bool isOpen)
        {
            RoomOptions roomOptions = new RoomOptions
            {
                MaxPlayers = (byte)maxPlayers,
                IsVisible = isVisible,
                IsOpen = isOpen
            };

            return roomOptions;
        }
        #endregion

        #region SyncChange

        /// <summary>
        /// �}�X�^�[�N���C�A���g�Ɠ����V�[���Ɉړ�������B
        /// </summary>
        /// <remarks> 
        /// ���̊֐����g�p����Ƃ��ɂ́APhotonNetwork.AutomaticallySyncScene = true �ɂ��Ă��������B
        /// </remarks>
        /// <param name ="sceneNumber"> �ڍs�������V�[���̔ԍ� </param>
        protected void SceneSyncChange(int sceneNumber)
        {
            if ( !PhotonNetwork.IsMasterClient) return;

            PhotonNetwork.LoadLevel(sceneNumber);
            Debug.Log($"<color=green> SceneSyncChange SceneNumber</color> : {sceneNumber}");
        }
        /// <summary>
        /// �}�X�^�[�N���C�A���g�Ɠ����V�[���Ɉړ�������B
        /// </summary>
        /// <remarks> 
        /// ���̊֐����g�p����Ƃ��ɂ́APhotonNetwork.AutomaticallySyncScene = true �ɂ��Ă��������B
        /// </remarks>
        /// <param name ="sceneName"> �ڍs�������V�[���̖��O </param>
        protected void SceneSyncChange(string sceneName)
        {
            if (!PhotonNetwork.IsMasterClient) return;

            PhotonNetwork.LoadLevel(sceneName);
            Debug.Log($"<color=green> SceneSyncChange SceneNumber</color> : {sceneName}");
        }

        #endregion

        #region recursive function

        /// <summary>
        /// �N���C�A���g�̏ꍇ�\������B
        /// </summary>
        /// <param name="obj"> �Ǘ��������I�u�W�F�N�g </param>
        protected void OnlyClientsDisplay(GameObject obj)
        {
            if (PhotonNetwork.IsMasterClient)
            {
                obj.SetActive(true);
                Debug.Log($" OnlyClientsDisplay {obj.name}.SetActive :<color=blue> true </color>");
            }
            else
            {
                obj.SetActive(false);
                Debug.Log($" OnlyClientsDisplay {obj.name}.SetActive :<color=blue> false </color>");
            }
        }

        /// <summary>
        /// �N���C�A���g�̂݊��\�ɂ���B
        /// </summary>
        /// <param name="button"> �Ǘ�������Button </param>
        protected void OnlyClientsCanInterfere(Button button)
        {
            if (PhotonNetwork.IsMasterClient)
            {
                button.interactable = true;
                Debug.Log($" OnlyClientsCanInterfere {button.name}.interactable :<color=blue> true </color>");
            }
            else
            {
                button.interactable = false;
                Debug.Log($" OnlyClientsCanInterfere {button.name}.interactable :<color=blue> false </color>");
            }
        }

        /// <summary>
        /// ���͂��ꂽ�������K���ł��邩�ǂ����̊m�F�����������Ԃ��B
        /// </summary>
        /// <param name="inputText"> ���͂��ꂽ�e�L�X�g </param>
        /// <returns></returns>
        protected string CheckForEnteredCharacters(string inputText)
        {
            Debug.Log($" CheckForEnteredCharacters input :<color=blue> {inputText}</color>");

            if (inputText == "")
            {
                inputText = UnityEngine.Random.Range(0, 10000).ToString();
                Debug.Log("<color=green> I defined a random name because it was not entered.</color>");
            }

            Debug.Log("CheckForEnteredCharacters :<color=green> clear </color>");

            return inputText;
        }

        /// <summary>
        /// �j�b�N�l�[���������l�����ׂ���B
        /// </summary>
        /// <param name="nickName"> �m�F�������j�b�N�l�[�� </param>
        /// <returns> �m�F��̃j�b�N�l�[�� </returns>
        protected string ConfirmationOfNicknames(string nickName)
        {
            if (PhotonNetwork.InRoom)
            {
                List<string> nickNameList = new List<string>(PhotonNetwork.PlayerList.Length);

                foreach (Player player in PhotonNetwork.PlayerList)
                {
                    nickNameList.Add(player.NickName);
                }

                nickNameList.Remove(nickName);

                foreach (string nameList in nickNameList)
                {
                    if (nickName == nameList)
                    {
                        nickName = nickName + "(1)";
                        Debug.Log($" {nickName} = {nickName + "(1)"}<color=green> The same name existed, so I changed it.</color>");
                    }
                }
            }

            return nickName;
        }

        /// <summary>
        /// �j�b�N�l�[���������l�����ׂ���B
        /// </summary>
        /// <remarks>
        /// �����̒��ɂ���v���C���[���X�g�̒��Ɏ����Ɠ������O���������ꍇ���g�̖��O��ύX���܂��B
        /// </remarks>>
        /// <param name="photonView">�@���g�̃j�b�N�l�[����������PhotonView </param>
        protected void ConfirmationOfNicknames(PhotonView photonView)
        {
            if (PhotonNetwork.InRoom) 
            {
                List<string> nickNameList = new List<string>(PhotonNetwork.PlayerList.Length);

                foreach (Photon.Realtime.Player player in PhotonNetwork.PlayerList)
                {
                    nickNameList.Add(player.NickName);
                }

                nickNameList.Remove(photonView.Owner.NickName);

                foreach (string nameList in nickNameList)
                {
                    if (photonView.Owner.NickName == nameList)
                    {
                        photonView.Owner.NickName = photonView.Owner.NickName + "(1)";
                        Debug.Log($" {photonView.Owner.NickName} = {photonView.Owner.NickName + "(1)"}<color=green> The same name existed, so I changed it.</color>");
                    }
                }

                Debug.Log("ConfirmationOfNicknames : <color=green>clear</color>");
            }
            else
            {
                Debug.LogError(" Please check your name in the room where your nickname is assigned. ");
            }
        }

        /// <summary>
        /// ���g�����������I�u�W�F�N�g�̏Փ˕������m�F���܂��B
        /// </summary>
        /// <returns> �ڐG�������@string �ŕԂ��܂��B</returns>
        protected string ConfirmationOfCollisionDirection_string(Collision collision)
        {
            string direction = "";
            float standardValue = 0.05f;

            foreach (ContactPoint point in collision.contacts)
            {
                Vector3 relativePoint = transform.InverseTransformPoint(point.point);

                //if (relativePoint.y > 0.5)
                //{
                //    Debug.Log("Up");
                //    direction = Vector3.up;
                //}

                if (relativePoint.z >= standardValue)
                {
                    direction = "Forward";
                }
                else if (relativePoint.z <= -standardValue)
                {
                    direction = "Back";
                }

                if (relativePoint.x >= standardValue)
                {
                    direction = "Right";
                }
                else if (relativePoint.x <= -standardValue)
                {
                    direction = "Left";
                }
            }

            Debug.Log(direction);

            return direction;
        }


        /// <summary>
        /// ���g�����������I�u�W�F�N�g�̏Փ˕������m�F���܂��B
        /// </summary>
        /// <param name="collision"></param>
        /// <returns> �ڐG�������@Vector3�ŕԂ��܂��B</returns>
        protected Vector3 ConfirmationOfCollisionDirection_vector3(Collision collision)
        {
            Vector3 direction = Vector3.zero;
            float standardValue = 0.05f;

            foreach ( ContactPoint point in collision.contacts)
            {
                Vector3 relativePoint = transform.InverseTransformPoint(point.point);

                //if (relativePoint.y > 0.5)
                //{
                //    Debug.Log("Up");
                //    direction = Vector3.up;
                //}

                if (relativePoint.z >= standardValue)
                {
                    direction = Vector3.forward;
                }
                else if (relativePoint.z <= -standardValue)
                {
                    direction = Vector3.back;
                }

                if (relativePoint.x >= standardValue)
                {
                    direction = Vector3.right;
                }
                else if (relativePoint.x <= -standardValue)
                {
                    direction = Vector3.left;
                }
            }

            return direction;
        }

        /// <summary>
        /// �񕪂̈�̊m����Ԃ��܂��B
        /// </summary>
        /// <returns></returns>
        protected bool ReturnsTheProbabilityOf1In2() { return UnityEngine.Random.Range(1, 10) % 2 == 0; }
        /// <summary>
        /// ���j���[�̏�Ԃ�ύX���܂��B
        /// </summary>
        /// <param name="menu"></param>
        protected void StateChangeOnMenu(GameObject menu) { menu.SetActive(!menu.activeSelf); }
        /// <summary>
        /// canvas�̏�Ԃ�ύX���܂��B
        /// </summary>
        /// <param name="canvas"></param>
        protected void StateChangeOnCanvas(Canvas canvas) { canvas.gameObject.SetActive(!canvas.gameObject.activeSelf); }

        #endregion

        #region PunCallbacks

        /// <summary>
        /// Photon����ؒf���ꂽ��
        /// </summary>
        /// <param name="cause">�@�ؒf���� </param>
        public override void OnDisconnected(DisconnectCause cause)
        {
            Debug.Log($" OnDisconnected Cause :<color=green> {cause}</color>");
        }

        /// <summary>
        /// �n�惊�X�g���󂯎������
        /// </summary>
        /// <param name="regionHandler">
        /// ��
        /// </param>
        /// <see cref="https://doc-api.photonengine.com/ja-jp/pun/v2/class_photon_1_1_realtime_1_1_region_handler.html"/>
        public override void OnRegionListReceived(RegionHandler regionHandler)
        {
            Debug.Log("OnRegionListReceived");
        }

        /// <summary>
        /// �J�X�^���F�؂̃��X�|���X����������
        /// </summary>
        /// <param name="data">
        /// 
        /// </param>
        public override void OnCustomAuthenticationResponse(Dictionary<string, object> data)
        {
            Debug.Log("OnCustomAuthenticationResponse");
        }

        /// <summary>
        /// �J�X�^���F�؂����s������
        /// </summary>
        /// <param name="debugMessage">
        /// �F�؂����s�������R�̃f�o�b�O ���b�Z�[�W���܂܂�Ă��܂��B����́A�J�����ɏC������K�v������܂��B
        /// </param>
        public override void OnCustomAuthenticationFailed(string debugMessage)
        {
            Debug.Log("OnCustomAuthenticationFailed");
            Debug.Log(debugMessage);
        }

        /// <summary>
        /// �t�����h���X�g�ɍX�V����������
        /// </summary>
        /// <param name="friendList">
        /// �t�����h�̃I�����C���󋵂ƁA�ǂ�Room�ɂ���̂��Ƃ������
        /// </param>
        /// <see cref="https://doc-api.photonengine.com/ja-jp/pun/current/class_friend_info.html"/>
        public override void OnFriendListUpdate(List<FriendInfo> friendList)
        {
            Debug.Log("OnFriendListUpdate");
        }

        /// <summary>
        /// �t�����h�̃��X�g�̕����ƃI�����C�� �X�e�[�^�X�����N�G�X�g���A���ʂ� PhotonNetwork.Friends �ɕۑ����܂��B
        /// </summary>
        /// <param name="friendsUserIds">
        /// �t�����hID
        /// </param>
        /// <returns></returns>
        public bool FindFriends(string[] friendsUserIds)
        {
            return PhotonNetwork.FindFriends(friendsUserIds);
        }

        /// <summary>
        /// �t�����h���X�g�̍X�V
        /// </summary>
        /// <param name="friendsInfo">
        /// �t�����h�̃I�����C���󋵂ƁA�ǂ�Room�ɂ���̂��Ƃ������
        /// </param>
        /// <see cref="https://doc-api.photonengine.com/ja-jp/pun/current/class_friend_info.html"/>
        protected void OnUpdatedFriendList(List<FriendInfo> friendsInfo)
        {
            for (int i = 0; i < friendsInfo.Count; i++)
            {
                FriendInfo friend = friendsInfo[i];
                Debug.LogFormat("{0}", friend);
            }
        }

        #endregion
    }
}
